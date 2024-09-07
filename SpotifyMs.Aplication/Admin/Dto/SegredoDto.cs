using System.ComponentModel.DataAnnotations;

namespace SpotifyMs.Aplication.Admin.Dto
{
    public class SegredoDto
    {
        [Required(ErrorMessage = "Campo chave é obrigatório")]
        public String Chave { get; set; }
        [Required(ErrorMessage = "Campo Valor é obrigatório")]
        public String Valor { get; set; }
    }
}
