using SpotifyMs.Aplication.Streaming.Dto;
using SpotifyMs.Domain.Streaming.Aggregates;

namespace SpotifyMs.Aplication.Streaming.Profile
{
    public class BandaProfile : AutoMapper.Profile
    {
        public BandaProfile()
        {
            CreateMap<BandaDto, Banda>()
                .ReverseMap();
        }
    }
}
