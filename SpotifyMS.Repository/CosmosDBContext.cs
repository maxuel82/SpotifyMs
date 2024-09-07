﻿using Microsoft.Azure.Cosmos;
using SpotifyMS.Domain.Admin;
using SpotifyMS.Repository.Repository;
using System;

namespace SpotifyMS.Repository
{
    public class CosmosDBContext
    {
        private CosmosClient client { get; set; }
        private SegredoRepository _segredoRepository { get; set; }

        private String AccountEndpoint { get; set; }
        private String TokenCredential { get; set; }

        private String DatabaseName = "spotifymsdbcosmo";

        private String ContainerName { get; set; }

        private Database Database { get; set; }
        private Container Container { get; set; }

        public CosmosDBContext(SegredoRepository segredoRepository)
        {
            _segredoRepository =segredoRepository;
            IEnumerable<Segredo> listasegredos = _segredoRepository.GetAll();

            var segredoEndPoint = listasegredos.FirstOrDefault(s => s.Chave == "COSMOS_DB_ENDPOINT");
            var segredoToken = listasegredos.FirstOrDefault(s => s.Chave == "COSMOS_DB_TOKEN");

            //foi criada uma tabela de segredos no banco que só é acessada apos a autenticação via token.
            this.AccountEndpoint = segredoEndPoint.Valor;
            this.TokenCredential = segredoToken.Valor;

            this.client = new CosmosClient(AccountEndpoint, TokenCredential);          
            this.Database = this.client.GetDatabase(this.DatabaseName);
        }

        public void SetContainer(string containerName)
        {
            this.ContainerName = containerName;
            this.Container = Database.GetContainer(this.ContainerName);
        }

        public async Task SaveOrUpate<T>(T entity, string partitionKey) where T : class
        {
            await Container.UpsertItemAsync<T>(item: entity, partitionKey: new PartitionKey(partitionKey));
        }

        public async Task Delete<T>(string id, string partitionKey) where T : class
        {
            var result = await Container.DeleteItemAsync<T>(id, new PartitionKey(partitionKey));
        }

        public async Task<List<T>> ReadAllItem<T>() where T : class
        {
            var query = new QueryDefinition(
                   query: "SELECT * FROM " + this.ContainerName
            );

            using FeedIterator<T> feedIterator = Container.GetItemQueryIterator<T>(query) as FeedIterator<T>;

            List<T> result = new List<T>();

            while (feedIterator.HasMoreResults)
            {
                FeedResponse<T> response = await feedIterator.ReadNextAsync();

                foreach (var item in response)
                {
                    result.Add(item);
                }
            }

            return result;

        }

        public async Task<T> ReadItem<T>(string id)
        {
            var query = new QueryDefinition(
                  query: "SELECT * FROM " + this.ContainerName + " c where c.id = @id"
            ).WithParameter("@id", id);

            using FeedIterator<T> feedIterator = Container.GetItemQueryIterator<T>(query) as FeedIterator<T>;

            List<T> result = new List<T>();

            while (feedIterator.HasMoreResults)
            {
                FeedResponse<T> response = await feedIterator.ReadNextAsync();

                foreach (var item in response)
                {
                    result.Add(item);
                }
            }

            return result.FirstOrDefault();
        }

    }
}