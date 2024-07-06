using SpotifyMs.Domain.Conta.Agreggates;
using SpotifyMs.Domain.Streaming.Aggregates;
using System.ComponentModel.DataAnnotations;

namespace SpotifyMs.Aplication.Streaming.Dto
{
    public class AlbumDto
    {
        public Guid Id { get; set; }

        [Required]
        public Guid BandaId { get; set; }

        [Required]
        public string Nome { get; set; }
        public List<MusicaDto> Musicas { get; set; } = new List<MusicaDto>();

    }
   

    public class MusicaDto
    {
        public Guid Id { get; set; }
        
        [Required(ErrorMessage = "Campo Nome é obrigatório")]
        public String Nome { get; set; }
        
        [Required(ErrorMessage = "Campo Duracao é obrigatório")]
        public int Duracao { get; set; }
        
        [Required(ErrorMessage = "Campo AlbumId é obrigatório")]
        public Guid AlbumId { get; set; }       
    }

    public class PlaylistDto
    {
       public Guid Id { get; set; }
       public string Nome { get; set; }
       public Boolean Publica { get; set; }   
       public Guid UsuarioId { get; set; }      
       public List<MusicaDto> Musicas { get; set; } = new List<MusicaDto>();
    }
}

