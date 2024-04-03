using AutoMapper;
using SpotifyMs.Aplication.Streaming.Dto;
using SpotifyMs.Domain.Conta.Agreggates;
using SpotifyMs.Domain.Streaming.Aggregates;
using SpotifyMS.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyMs.Aplication.Streaming
{
    public class PlaylistService
    {
        private PlaylistRepository PlaylistRepository { get; set; }

        private IMapper Mapper { get; set; }


        public PlaylistService(PlaylistRepository playlistRepository, IMapper mapper)
        {
            PlaylistRepository = playlistRepository;

            Mapper = mapper;
        }


        public IEnumerable<PlaylistDto> GetAll()
        {
            var playlist = this.PlaylistRepository.GetAll();
            return this.Mapper.Map<IEnumerable<PlaylistDto>>(playlist);
        }



        public PlaylistDto AssociarMusicaAPlaylist(PlaylistDto dto)
        {
            var playlist = this.PlaylistRepository.GetById(dto.PlaylistId);

            if (playlist == null)
            {
                throw new Exception("Playlista não encontrada");
            }

            this.playlistDtoParaplaylist(playlist, dto);
                       
            this.PlaylistRepository.Update(playlist);

            var result = this.PlaylistParaplaylistDto(playlist);

            return result;
        }

        /*talves crie um playlist service*/
        private void playlistDtoParaplaylist(Playlist playlist, PlaylistDto dto)
        {
            foreach (MusicaDto item in dto.Musicas)
            {
                Musica musica = new Musica();
                musica.Id = item.Id;
                musica.Nome = item.Nome;
                musica.Duracao = new Domain.Streaming.ValueObject.Duracao(item.Duracao);

                playlist.AdicionarMusica(musica);
            }          
        }

        private PlaylistDto PlaylistParaplaylistDto(Playlist playlist)
        {
            PlaylistDto dto = new PlaylistDto();
            dto.PlaylistId = playlist.Id;

            foreach (var item in playlist.Musicas)
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
        ///

        ///

    }
}
