using SpotifyMs.Domain.Conta.Agreggates;
using SpotifyMs.Domain.Streaming.ValueObject;

namespace SpotifyMs.Domain.Streaming.Aggregates
{
    public class Musica
    {
        public Guid Id { get; private set; }
        public String Nome { get; private set; }
        public Duracao Duracao { get; private set; }

        public List<Playlist> Playlists { get; set; } = new List<Playlist>();

        public static Musica Criar(string nome, Duracao duracao)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new Exception("Informe o nome da musica.");

            return new Musica()
            {
                Id = Guid.NewGuid(),
                Nome = nome,
                Duracao = new Duracao(duracao),
            };
        }

    }
}
