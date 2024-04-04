using SpotifyMs.Aplication.Streaming.Dto;
using SpotifyMs.Domain.Streaming.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyMs.Aplication.Streaming.Profile
{
    public class MusicaProfile : AutoMapper.Profile
    {
        public MusicaProfile()
        {
            CreateMap<MusicaDto, Musica>()
                .ReverseMap();
        }
    }
}
