using AutoMapper;
using SpotifyMs.Aplication.Streaming.Dto;
using SpotifyMs.Domain.Conta.Agreggates;
using SpotifyMs.Domain.Streaming.Aggregates;
using SpotifyMS.Repository.Repository;
using System.Numerics;

namespace SpotifyMs.Aplication.Streaming
{
    public class PlaylistService
    {
        private IMapper Mapper { get; set; }
        private PlaylistRepository _playlistRepository { get; set; }
        private UsuarioRepository _usuarioRepository { get; set; }
        
        private MusicaRepository _musicaRepository { get; set; }


        public PlaylistService(IMapper mapper, PlaylistRepository playlistRepository, UsuarioRepository usuarioRepository
            , MusicaRepository musicaRepository)
        {
            _playlistRepository = playlistRepository;
            _usuarioRepository = usuarioRepository;
            _musicaRepository = musicaRepository;

            Mapper = mapper;
        }

        
        public IEnumerable<PlaylistDto> GetAll()
        {
            var playlist = this._playlistRepository.GetAll();
            return this.Mapper.Map<IEnumerable<PlaylistDto>>(playlist);
        }        


        public PlaylistDto AssociarMusicaAPlaylist(PlaylistDto dto)
        {
            var playlist = this._playlistRepository.GetById(dto.Id);

            if (playlist == null)
            {
                throw new Exception("Playlista não encontrada");
            }

            this.playlistDtoParaplaylist(playlist, dto);
                       
            this._playlistRepository.Update(playlist);

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
            dto.Id = playlist.Id;

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

        public PlaylistDto FavoritarMusica(Guid usuarioId, Guid musicaId)
        {
            var usuario = this._usuarioRepository.GetById(usuarioId);

            if (usuario == null)
                throw new Exception("Não foi encontrada o Usuario");

            var playlistFavorita = usuario.FindPlaylistFavorita();

            if (playlistFavorita == null)
                throw new Exception("Não foi encontrada a referencia da PlayList Favorita");

            var musica = this._musicaRepository.GetById(musicaId);

            if (musica == null)
                throw new Exception("Não foi encontrada a referencia da musica");

            playlistFavorita.AdicionarMusica(musica);

            this._playlistRepository.Update(playlistFavorita);         

            var result = this.Mapper.Map<PlaylistDto>(playlistFavorita);
           return result;
        }

        ///

    }
}
