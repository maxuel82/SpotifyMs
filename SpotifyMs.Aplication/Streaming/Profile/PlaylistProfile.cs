using SpotifyMs.Aplication.Streaming.Dto;
using SpotifyMs.Domain.Conta.Agreggates;
using SpotifyMs.Domain.Streaming.Aggregates;

namespace SpotifyMs.Aplication.Streaming.Profile
{
    public class PlaylistProfile : AutoMapper.Profile
    {
        public PlaylistProfile()
        {
            CreateMap<PlaylistDto, Playlist>()
                .ReverseMap();
        }
    }

}
