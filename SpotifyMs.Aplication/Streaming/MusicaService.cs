using AutoMapper;
using SpotifyMs.Aplication.Conta.Dto;
using SpotifyMs.Aplication.Streaming.Dto;
using SpotifyMs.Domain.Conta.Agreggates;
using SpotifyMs.Domain.Streaming.Aggregates;
using SpotifyMS.Repository.Repository;


namespace SpotifyMs.Aplication.Streaming
{
    public class MusicaService
    {
        private MusicaRepository MusicaRepository { get; set; }
        
        private IMapper Mapper { get; set; }


        public MusicaService(MusicaRepository musicaRepository, IMapper mapper)
        {
            MusicaRepository = musicaRepository;           

            Mapper = mapper;
        }

        public IEnumerable<MusicaDto> GetAll()
        {
            var musica = this.MusicaRepository.GetAll();
            return this.Mapper.Map<IEnumerable<MusicaDto>>(musica);
        }

        public IEnumerable<MusicaDto> Buscar(String nome)
        {
            var musica = this.MusicaRepository.Buscar(nome);
            return this.Mapper.Map<IEnumerable<MusicaDto>>(musica);
        }

        public MusicaDto Criar(MusicaDto dto)
        {
            Musica musica = this.Mapper.Map<Musica>(dto);
            this.MusicaRepository.Save(musica);

            return this.Mapper.Map<MusicaDto>(musica);
        }

    }
}

