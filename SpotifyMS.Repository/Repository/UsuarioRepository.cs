using SpotifyMs.Domain.Conta.Agreggates;

namespace SpotifyMS.Repository.Repository
{
    public class UsuarioRepository : RepositoryBase<Usuario>
    {
        public UsuarioRepository(SpotifyMSContext context) : base(context)
        {
            Context = context;
        }

        //public Usuario GetById(Guid id)
        //{
        //    return this.Context.Usuarios
        //               .Include(x => x.Assinaturas) //Caso não esteja usando lazy loading
        //               .Include(x => x.Playlists)
        //               .Include(x => x.Notificacoes)
        //               //.AsSplitQuery() //Quebra a consulta por cada tipo
        //               .FirstOrDefault(x => x.Id == id);
        //}


    }
}
