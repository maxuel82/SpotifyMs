using AutoMapper;
using SpotifyMs.Aplication.Streaming.Dto;
using SpotifyMs.Domain.Streaming.Aggregates;
using SpotifyMS.Repository.Repository;

namespace SpotifyMs.Aplication.Streaming
{
    public class BandaService
    {
        private BandaRepository BandaRepository { get; set; }
        private IMapper Mapper { get; set; }


        public BandaService(BandaRepository bandaRepository, IMapper mapper)
        {
            BandaRepository = bandaRepository;
            Mapper = mapper;
        }

        public BandaDto Criar(BandaDto dto)
        {
            Banda banda = this.Mapper.Map<Banda>(dto);
            this.BandaRepository.Save(banda);

            return this.Mapper.Map<BandaDto>(banda);
        }

        public BandaDto Obter(Guid id)
        {
            var banda = this.BandaRepository.GetById(id);
            return this.Mapper.Map<BandaDto>(banda);
        }

        public IEnumerable<BandaDto> Obter()
        {
            var banda = this.BandaRepository.GetAll();
            return this.Mapper.Map<IEnumerable<BandaDto>>(banda);
        }

        public AlbumDto AssociarAlbum(AlbumDto dto)
        {
            var banda = this.BandaRepository.GetById(dto.BandaId);

            if (banda == null)
            {
                throw new Exception("Banda não encontrada");
            }

            var novoAlbum = this.AlbumDtoParaAlbum(dto);

            banda.AdicionarAlbum(novoAlbum);
            //faz update para atualizar banda
            this.BandaRepository.Update(banda);

            var result = this.AlbumParaAlbumDto(novoAlbum);

            return result;

        }

        public AlbumDto ObterAlbumPorId(Guid idBanda, Guid id)
        {
            var banda = this.BandaRepository.GetById(idBanda);

            if (banda == null)
            {
                throw new Exception("Banda não encontrada");
            }

            var album = (from x in banda.Albums
                         select x
                         ).FirstOrDefault(x => x.Id == id);

            var result = AlbumParaAlbumDto(album);
            result.BandaId = banda.Id;

            return result;

        }

        public List<AlbumDto> ObterAlbum(Guid idBanda)
        {
            var banda = this.BandaRepository.GetById(idBanda);

            if (banda == null)
            {
                throw new Exception("Banda não encontrada");
            }

            var result = new List<AlbumDto>();

            foreach (var item in banda.Albums)
            {
                result.Add(AlbumParaAlbumDto(item, idBanda));
            }

            return result;

        }

        private Album AlbumDtoParaAlbum(AlbumDto dto)
        {
            Album album = new Album()
            {
                Nome = dto.Nome
            };

            foreach (MusicaDto item in dto.Musicas)
            {
                 album.AdicionarMusica(new Musica
                {
                    Nome = item.Nome,
                    Duracao = new Domain.Streaming.ValueObject.Duracao(item.Duracao)
                });
                 /*DUVIDA -REMOVER, talvez o contstrutor já crieo o guid*/
                /*album.AdicionarMusica(Musica.Criar(item.Nome, item.Duracao));*/
            }

            return album;
        }

        private AlbumDto AlbumParaAlbumDto(Album album, Guid? idBanda = null)
        {
            AlbumDto dto = new AlbumDto(); 
            dto.Id = album.Id;
            dto.Nome = album.Nome;
            /*Para  retornar na requisição o Id da banda, não estava retornando*/ 
            if (idBanda.HasValue)
            {
                dto.BandaId = (Guid)idBanda;
            }
            

            foreach (var item in album.Musica)
            {
                var musicaDto = new MusicaDto()
                {
                    Id = item.Id,
                    Duracao = item.Duracao.Valor,
                    Nome = item.Nome
                };

                dto.Musicas.Add(musicaDto);
            }

            return dto;
        }



    }
}
