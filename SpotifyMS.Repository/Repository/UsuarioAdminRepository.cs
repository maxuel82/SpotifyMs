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
        //nessa implementação foi utilizado mesmo contexto da api.
        public UsuarioAdminRepository(SpotifyMSContext context) : base(context)
        { 
        
        }

        public UsuarioAdmin GetUsuarioAdminByEmailAndPassword(string email, string senha)
        {
            return this.Find(x => x.Email == email && x.Senha == senha).FirstOrDefault();  
        }
    }
}
