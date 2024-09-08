using AutoMapper;
using SpotifyMs.Aplication.Streaming.Dto;
using SpotifyMs.Aplication.Streaming.Storage;
using SpotifyMs.Domain.Streaming.Aggregates;
using SpotifyMS.Repository.Repository;

namespace SpotifyMs.Aplication.Streaming
{
    public class BandaCosmoService
    {
        private BandaCosmoRepository BandaRepository { get; set; }
        private IMapper Mapper { get; set; }

        private AzureStorageAccount AzureStorageAccount { get; set; }

        public BandaCosmoService(BandaCosmoRepository bandaRepository, IMapper mapper, AzureStorageAccount azureStorageAccount)
        {
            BandaRepository = bandaRepository;           
            Mapper = mapper;
            AzureStorageAccount = azureStorageAccount;         
        }

        public async Task<BandaDto> Criar(BandaDto dto)
        {
            BandaCosmo bandaCosmo = this.Mapper.Map<BandaCosmo>(dto);

            var urlBackdrop = await this.AzureStorageAccount.UploadImage(dto.Backdrop);

            bandaCosmo.Backdrop = urlBackdrop;

            await this.BandaRepository.SaveOrUpate(bandaCosmo, bandaCosmo.PartitionKey);

            return this.Mapper.Map<BandaDto>(bandaCosmo);
        }

     
        public async Task<BandaDto> Obter(Guid id)
        {
            var bandaCosmo = await this.BandaRepository.ReadItem<BandaCosmo>(id.ToString());
            return this.Mapper.Map<BandaDto>(bandaCosmo);
        }

        public async Task<IEnumerable<BandaDto>> Obter()
        {
            var bandaCosmo = await this.BandaRepository.ReadAllItem<BandaCosmo>();
            return this.Mapper.Map<IEnumerable<BandaDto>>(bandaCosmo);
        }
    }
}
