using SpotifyMs.Domain.Streaming.Aggregates;

namespace SpotifyMS.Repository.Repository
{
    public class BandaRepository : RepositoryBase<Banda>
    {
        public BandaRepository(SpotifyMSContext context) : base(context)
        {

        }
    }
}
