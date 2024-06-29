using SpotifyMs.Domain.Conta.Agreggates;
using SpotifyMs.Domain.Streaming.ValueObject;

namespace SpotifyMs.Domain.Streaming.Aggregates
{
    public class Musica
    {
        public Guid Id { get; set; }
        public String Nome { get; set; }
        public Duracao Duracao { get; set; }
        public Guid AlbumId { get; set; }

        //exemplo de relação n x n musica e playlist
        public virtual IList<Playlist> Playlists { get; set; } = new List<Playlist>();

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

        /*Retornei os atributos para escrita publica, defido a erro na associação de ambum a banda.  private set;   para set*/
		
		/*construtor Musica Criar  \BandaService.cs quando criou banca  esta chamando esse contrutor que alimenta o Id 
		 e na hora da gravação do ambum, o EF tentou fazer update na musica ao inves de fazer insert,  mantendo o construtor 
		 devido ao uso no teste unitario*/