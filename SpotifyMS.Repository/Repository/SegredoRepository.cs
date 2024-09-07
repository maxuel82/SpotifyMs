using SpotifyMS.Domain.Admin;

namespace SpotifyMS.Repository.Repository
{
    public class SegredoRepository : RepositoryBase<Segredo>
    {
        public SegredoRepository(SpotifyMSContext context) : base(context)
        {

        }

        public Segredo Find(string chave)
        {
            return this.Find(x => x.Chave == chave).FirstOrDefault();
        }
    }
}
