using SpotifyMs.Domain.Conta.Agreggates;
using SpotifyMs.Domain.Notificacao;
using SpotifyMs.Domain.Streaming.Aggregates;
using SpotifyMs.Domain.Transacao.Agreggates;
using System.Numerics;

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

            Usuario usuarioDestino = new Usuario() 
            {
               Nome = "Usuario Destino",
               Email = "usuario.destino@teste.com",
               Senha = "123456"
             };

            Usuario usuarioRemetente = new Usuario()
            {
                Nome = "Usuario Remetente",
                Email = "usuario.remetente@teste.com",
                Senha = "654321"
            };

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

            Usuario usuarioDestino = new Usuario()
            {
                Nome = "Usuario Destino",
                Email = "usuario.destino@teste.com",
                Senha = "123456"
            };


            Assert.Throws<ArgumentNullException>(() =>
            {
               SpotifyMs.Domain.Notificacao.Notificacao.Criar(titulo, menssagem, TipoNotificacao.Usuario, usuarioDestino, null);
            });

        }
    }
}
