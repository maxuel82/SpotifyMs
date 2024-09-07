using Microsoft.Extensions.Configuration;
using SpotifyMS.Repository;

namespace SpotifyMS.Repository.Repository
{
    public class BandaCosmoRepository : CosmosDBContext
    {
        public BandaCosmoRepository(IConfiguration configuration) : base(configuration)
        {
            this.SetContainer("banda");
        }
    }
}
