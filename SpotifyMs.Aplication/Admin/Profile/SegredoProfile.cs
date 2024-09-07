using SpotifyMs.Aplication.Admin.Dto;
using SpotifyMS.Domain.Admin;

namespace SpotifyMs.Aplication.Admin.Profile
{
    public class SegredoProfile : AutoMapper.Profile
    {
        public SegredoProfile()
        {
            CreateMap<SegredoDto, Segredo>()
                .ReverseMap();
        }
    }
}
