using SpotifyMs.Domain.Streaming.Aggregates;

namespace SpotifyMS.Repository.Repository
{
    public class MusicaRepository : RepositoryBase<Musica>
    {
        public MusicaRepository(SpotifyMSContext context) : base(context)
        {

        }

        public IEnumerable<Musica> Buscar(string nome)
        {
            return Find(m => m.Nome.Contains(nome));
        }
    }
}
