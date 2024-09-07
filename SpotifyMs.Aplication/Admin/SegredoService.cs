using AutoMapper;
using SpotifyMs.Aplication.Admin.Dto;
using SpotifyMS.Domain.Admin;
using SpotifyMS.Repository.Repository;

namespace SpotifyMs.Aplication.Admin
{
    public class SegredoService
    {
        private SegredoRepository _segredoRepository { get; set; }
        private IMapper Mapper { get; set; }


        public SegredoService(SegredoRepository segredoRepository, IMapper mapper)
        {
            _segredoRepository = segredoRepository;
            Mapper = mapper;
        }


        public SegredoDto Criar(SegredoDto dto)
        {
            Segredo segredo = this.Mapper.Map<Segredo>(dto);
            this._segredoRepository.Save(segredo);

            return this.Mapper.Map<SegredoDto>(segredo);
        }


        public SegredoDto Obter(string chave)
        {
            var segredo = this._segredoRepository.Find(chave);
            return this.Mapper.Map<SegredoDto>(segredo);
        }

        public IEnumerable<SegredoDto> Obter()
        {
            var segredo = this._segredoRepository.GetAll();
            return this.Mapper.Map<IEnumerable<SegredoDto>>(segredo);
        }

    }
}
