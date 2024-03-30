using SpotifyMs.Domain.Streaming.Aggregates;

namespace SpotifyMS.Repository.Repository
{
    public class PlanoRepository : RepositoryBase<Plano>
    {
        public SpotifyMSContext Context { get; set; }

        public PlanoRepository(SpotifyMSContext context) : base(context)
        {
            Context = context;
        }

       
    }
}
