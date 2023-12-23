using SpotifyMs.Domain.Conta.Agreggates;
using SpotifyMs.Domain.Streaming.Aggregates;
using SpotifyMs.Domain.Transacao.Agreggates;

namespace SpotifyMs.Tests.Domain
{
    public class UsuarioTest
    {
        [Fact]
        public void DeveCriarUsuarioComSucesso()
        {

            Plano plano = Plano.Criar("Plano prêmio", 19.90M);

            Cartao cartao = new Cartao()
            {
                Id = Guid.NewGuid(),
                Ativo = true,
                Limite = 1000M,
                Numero = "6465465466",
            };

            string nome = "Usuario Teste";
            string email = "usuario.teste@teste.com";
            string senha = "123456";

            //Act
            Usuario usuario = new Usuario();
            usuario.CriarConta(nome, email, senha, DateTime.Now, plano, cartao);

            //Assert
            Assert.NotNull(usuario.Email);
            Assert.NotNull(usuario.Nome);
            Assert.True(usuario.Email == email);
            Assert.True(usuario.Nome == nome);
            Assert.True(usuario.Senha != senha);

            Assert.True(usuario.Assinaturas.Count > 0);
            Assert.Same(usuario.Assinaturas[0].Plano, plano);

            Assert.True(usuario.Cartoes.Count > 0);
            Assert.Same(usuario.Cartoes[0], cartao);

            Assert.True(usuario.Playlists.Count > 0);
            Assert.True(usuario.Playlists[0].Nome == Usuario.PLAYLIST_FAVORITAS);
            Assert.False(usuario.Playlists[0].Publica);
        }

        [Fact]
        public void NaoDeveCriarUsuarioComCartaoSemLimite()
        {

            Plano plano = Plano.Criar("Plano prêmio", 19.90M);

            Cartao cartao = new Cartao()
            {
                Id = Guid.NewGuid(),
                Ativo = true,
                Limite = 10M,
                Numero = "6465465466",
            };

            string nome = "Usuario Teste";
            string email = "usuario.teste@teste.com";
            string senha = "123456";

            //Act
            Assert.Throws<Exception>(() =>
            {
                Usuario usuario = new Usuario();
                usuario.CriarConta(nome, email, senha, DateTime.Now, plano, cartao);
            });
        }

        [Fact]
        public void NaoDeveCriarUsuarioComCartaoInativo()
        {

            Plano plano = Plano.Criar("Plano prêmio", 19.90M);

            Cartao cartao = new Cartao()
            {
                Id = Guid.NewGuid(),
                Ativo = false,
                Limite = 10M,
                Numero = "6465465466",
            };

            string nome = "Usuario Teste";
            string email = "usuario.teste@teste.com";
            string senha = "123456";

            //Act
            Assert.Throws<Exception>(() =>
            {
                Usuario usuario = new Usuario();
                usuario.CriarConta(nome, email, senha, DateTime.Now, plano, cartao);
            });
        }
        
    }
}
