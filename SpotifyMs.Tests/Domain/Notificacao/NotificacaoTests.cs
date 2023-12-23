using SpotifyMs.Domain.Conta.Agreggates;
using SpotifyMs.Domain.Notificacao;

namespace SpotifyMS.Tests.Domain.Notificacao
{
    public class NotificacaoTests
    {
        [Fact]
        public void NotificacaoTransacaoUsuarioComSucesso()
        {

            //Act
            string titulo = "Titulo teste notificação sucesso";
            string menssagem = "Mensagem sucesso";

            Usuario usuarioDestino  = Usuario.Criar("Usuario Destino", "usuario.destino@teste.com", "123456", DateTime.Now.AddYears(-18));
            
            Usuario usuarioRemetente = Usuario.Criar("Usuario Remetente", "usuario.remetente@teste.com", "654321", DateTime.Now.AddYears(-25));

            var notificacao = SpotifyMs.Domain.Notificacao.Notificacao.Criar(titulo, menssagem, TipoNotificacao.Usuario, usuarioDestino, usuarioRemetente);
            usuarioDestino.Notificacoes.Add(notificacao);

            Assert.True(usuarioDestino.Notificacoes.Count > 0);
            Assert.Same(usuarioDestino.Notificacoes[0].Titulo, titulo);
        }

        [Fact]
        public void NotificacaoInvalida()
        {

            //Act
            string titulo = "Titulo teste notificação sucesso";
            string menssagem = "Mensagem sucesso";

            Usuario usuarioDestino = Usuario.Criar("Usuario Destino", "usuario.destino@teste.com", "123456", DateTime.Now.AddYears(-18));                      

            Assert.Throws<ArgumentNullException>(() =>
            {
               SpotifyMs.Domain.Notificacao.Notificacao.Criar(titulo, menssagem, TipoNotificacao.Usuario, usuarioDestino, null);
            });

        }
    }
}
