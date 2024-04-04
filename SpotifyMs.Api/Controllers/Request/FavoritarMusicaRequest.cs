using System.ComponentModel.DataAnnotations;

namespace SpotifyMs.Api.Controllers.Request
{
    public class FavoritarMusicaRequest
    {
        [Required(ErrorMessage = "Usuario é obrigatório")]
        public Guid UsuarioId { get; set; }

        [Required(ErrorMessage = "Musica é obrigatória")]
        public Guid MusicaId { get; set; }
    }
}
