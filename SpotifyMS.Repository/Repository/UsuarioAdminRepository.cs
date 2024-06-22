using SpotifyMs.Domain.Streaming.Aggregates;
using SpotifyMS.Domain.Admin.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyMS.Repository.Repository
{
    public class UsuarioAdminRepository : RepositoryBase<UsuarioAdmin>
    {
        public UsuarioAdminRepository(SpotifyMSContext context) : base(context)
        {

        }
    }
}
