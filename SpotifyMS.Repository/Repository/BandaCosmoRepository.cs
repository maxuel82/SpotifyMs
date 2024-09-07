using Microsoft.Extensions.Configuration;
using SpotifyMS.Repository;

namespace SpotifyMS.Repository.Repository
{
    public class BandaCosmoRepository : CosmosDBContext
    {
        public BandaCosmoRepository(SegredoRepository segredoRepository) : base(segredoRepository)
        {
            this.SetContainer("banda");
        }
    }
}
