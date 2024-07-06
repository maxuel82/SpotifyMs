using System.ComponentModel.DataAnnotations;
namespace SpotifyMs.Admin.Models
{
    public class LoginRequest
    {
        [Required(ErrorMessage = "Campo Email é obrigatório")]
        [EmailAddress(ErrorMessage = "Campo Email não está em um formato correto")]
        public String Email { get; set; }

        [Required(ErrorMessage = "Campo Senha é obrigatório")]
        [DataType(DataType.Password)]
        public String Senha { get; set; }
    }
}
