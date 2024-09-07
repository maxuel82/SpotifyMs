using SpotifyMs.Aplication.Streaming.Dto;
using SpotifyMs.Domain.Streaming.Aggregates;

namespace SpotifyMs.Aplication.Streaming.Profile
{
    public class BandaCosmoProfile : AutoMapper.Profile
    {
        public BandaCosmoProfile()
        {
            CreateMap<BandaDto, BandaCosmo>()
                .ReverseMap();
        }
    }
}
