using System.ComponentModel.DataAnnotations;

namespace SpotifyMs.Aplication.Streaming.Dto
{
    public class BandaDto
    {
        public Guid Id { get; set; }


        [Required(ErrorMessage = "Campo Nome é obrigatório")]
        public String Nome { get; set; }

        [Required(ErrorMessage = "Campo Descricao é obrigatório")]
        public String Descricao { get; set; }

        [Required(ErrorMessage = "Campo Backdrop é obrigatório")]
        public String Backdrop { get; set; }

    }
}
