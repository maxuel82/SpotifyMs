using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyMS.Domain.Admin.Aggregates
{
    public class UsuarioAdmin
    {
        public Guid Id { get; set; }
        public String Nome { get; set; }
        public String Email { get; set; }
        public String Senha { get; set; }
        public Perfil Perfil { get; set; }
    }
}
