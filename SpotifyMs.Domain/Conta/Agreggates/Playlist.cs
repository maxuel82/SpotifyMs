using SpotifyMs.Domain.Streaming.Aggregates;

namespace SpotifyMs.Domain.Conta.Agreggates
{
    public class Playlist
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public Boolean Publica { get; set; }
        public virtual Usuario Usuario { get; set; } 
        public virtual IList<Musica> Musicas { get; set; }
        public DateTime DtCriacao { get; set; }

    }
}

