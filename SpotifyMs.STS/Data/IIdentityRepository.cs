using SpotifyMs.STS.Model;
namespace SpotifyMs.STS.Data
{
    public interface IIdentityRepository
    {
        Task<Usuario> FindByEmailAndPasswordAsync(string email, string password);
        Task<Usuario> FindByIdAsync(Guid id);
    }
}
