using Azure.Storage;
using Azure.Storage.Blobs;
using Microsoft.Extensions.Configuration;
using SpotifyMS.Domain.Admin;
using SpotifyMS.Repository.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyMs.Aplication.Streaming.Storage
{
    public class AzureStorageAccount
    {
        private SegredoRepository SegredoRepository { get; set; }

        private String AccountName { get; set; }
        private String AccessKey { get; set; }

        public AzureStorageAccount(SegredoRepository segredoRepository)
        {
            //    this.AccountName = configuration["AzureStorageAccount:AccountName"];
            //    this.AccessKey = configuration["AzureStorageAccount:AccessKey"];

            this.SegredoRepository = segredoRepository;
            IEnumerable<Segredo> listasegredos = SegredoRepository.GetAll();
            var segredoAccountName = listasegredos.FirstOrDefault(s => s.Chave == "BLOB_ACCOUNT_NAME");
            var segredoAccessKey = listasegredos.FirstOrDefault(s => s.Chave == "BLOB_ACESS_KEY");

            this.AccountName = segredoAccountName.Valor;
            this.AccessKey = segredoAccessKey.Valor;
        }

        public async Task<String> UploadImage(String base64Image)
        {

            //Converte a imagem em base 64 para memoria
            byte[] imageByte = Convert.FromBase64String(base64Image);

            MemoryStream stream = new MemoryStream(imageByte);

            StorageSharedKeyCredential sharedKeyCredential = new StorageSharedKeyCredential(this.AccountName, this.AccessKey);

            string blobUri = $"https://{this.AccountName}.blob.core.windows.net";

            var blobServiceClient = new BlobServiceClient(new Uri(blobUri), sharedKeyCredential);

            string fileName = $"{Guid.NewGuid().ToString().Replace("-", "")}.jpg";

            var blobContainer = blobServiceClient.GetBlobContainerClient("backdrop-images");

            BlobClient blobClient = blobContainer.GetBlobClient(fileName);

            await blobClient.UploadAsync(stream, true);

            return $"https://{this.AccountName}.blob.core.windows.net/backdrop-images/{fileName}";

        }

    }
}
