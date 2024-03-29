using SpotifyMs.Domain.Conta.Agreggates;

namespace SpotifyMs.Domain.Notificacao
{
    public class Notificacao
    {
        public const string NOTIFICACAO_TRANSACAO_AUTORIZADA = "Transação realizada.";

        public Guid Id { get; set; }
        public DateTime DataNotificacao { get; set; }
        public String Mensagem { get; set; }
        public String Titulo { get; set; }
        public virtual Usuario UsuarioDestino { get; set; }
        public virtual Usuario? UsuarioRemetente { get; set; }
        public TipoNotificacao TipoNotificacao { get; set; }


        public static Notificacao Criar(string titulo, string mensagem, TipoNotificacao tipoNotificacao, Usuario destino, Usuario remetente = null)
        {
            if (tipoNotificacao == TipoNotificacao.Usuario && remetente == null)
                throw new ArgumentNullException("Para tipo de mensagem 'usuário', você deve informar quem foi o remetente");

            if (string.IsNullOrWhiteSpace(titulo))
                throw new ArgumentNullException("Informe o titulo da notificacao");

            if (string.IsNullOrWhiteSpace(mensagem))
                throw new ArgumentNullException("Informe o mensagem da notificacao");

            return new Notificacao()
            {
                DataNotificacao = DateTime.Now,
                Mensagem = mensagem,
                TipoNotificacao = tipoNotificacao,
                Titulo = titulo,
                UsuarioDestino = destino,
                UsuarioRemetente = remetente
            };
        }
    }

    public enum TipoNotificacao
    {
        Usuario = 1,
        Sistema = 2
    }
}
