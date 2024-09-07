using AutoMapper;
using SpotifyMs.Aplication.Streaming.Dto;
using SpotifyMs.Domain.Streaming.Aggregates;
using SpotifyMS.Repository.Repository;

namespace SpotifyMs.Aplication.Streaming
{
    public class BandaCosmoService
    {
        private BandaCosmoRepository BandaRepository { get; set; }
        private IMapper Mapper { get; set; }


        public BandaCosmoService(BandaCosmoRepository bandaRepository, IMapper mapper)
        {
            BandaRepository = bandaRepository;
            Mapper = mapper;
        }

        public async Task<BandaDto> Criar(BandaDto dto)
        {
            BandaCosmo bandaCosmo = this.Mapper.Map<BandaCosmo>(dto);

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
