using System.ComponentModel.DataAnnotations;

namespace SpotifyLike.Api.Controllers.Request
{
    public class LoginRequest
    {

        [Required(ErrorMessage = "Email é obrigatório")]
        public String Email { get; set; }

        [Required(ErrorMessage = "Senha é obrigatória")]
        public String Senha { get; set; }
    }
}
