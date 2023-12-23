using SpotifyMs.Domain.Core.ValueObject;
using SpotifyMs.Domain.Notificacao;
using SpotifyMs.Domain.Streaming.Aggregates;
using SpotifyMs.Domain.Transacao.Agreggates;
using SpotifyMs.Domain.Transacao.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace SpotifyMs.Domain.Conta.Agreggates
{
    public class Usuario
    {

        public const string PLAYLIST_FAVORITAS = "Favoritas";
        private const string SUFIXO_TRANSACAO = "Assinatura Plano:";

        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }
        public DateTime DtNascimento { get; private set; }
        public List<Cartao> Cartoes { get; set; } = new List<Cartao>();
        public List<Assinatura> Assinaturas { get; set; } = new List<Assinatura>();
        public List<Playlist> Playlists { get; set; } = new List<Playlist>();
        public List<Notificacao.Notificacao> Notificacoes { get; set; } = new List<Notificacao.Notificacao>();


        public static Usuario Criar(string nome, string email, string senha, DateTime dtNascimento)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new Exception("Informe o nome do usuario.");

            Usuario usuario = new Usuario()           
            {
                Id = Guid.NewGuid(),
                Nome = nome,
                Email = email,
                Senha = senha
            };

            usuario.Senha = usuario.CriptografarSenha(usuario.Senha);

            return usuario;
        }
        public static Usuario CriarConta(string nome, string email, string senha, DateTime dtNascimento ,Plano plano, Cartao cartao)
        {
            Usuario usuario = Usuario.Criar(nome, email, senha, dtNascimento);

            //Assinar um plano
            usuario.AssinarPlano(plano, cartao);

            //Adicionar cartão
            usuario.AdicionarCartao(cartao);

            //Criar a playlist Favorita
            usuario.CriarPlaylist(nome: PLAYLIST_FAVORITAS, publica: false);

            return usuario;
        }

        public void CriarPlaylist(string nome, bool publica = true)
        {
            this.Playlists.Add(new Playlist()
            {
                Nome = nome,
                Publica = publica,
                DtCriacao = DateTime.Now,
                Usuario = this
            });
        }

        private void AdicionarCartao(Cartao cartao) 
            => this.Cartoes.Add(cartao);

        private void AssinarPlano(Plano plano, Cartao cartao)
        {
            //Debitar o valor do plano no cartao
            cartao.CriarTransacao(new Comerciante() { Nome = plano.Nome }, new Monetario(plano.Valor), SUFIXO_TRANSACAO + plano.Nome);

            //Desativo caso tenha alguma assinatura ativa
            DesativarAssinaturaAtiva();

            //Adiciona uma nova assinatura
            this.Assinaturas.Add(new Assinatura()
            {
                Ativo = true,
                Plano = plano,
                DtAtivacao = DateTime.Now,
            });

            //Adicionar notificação de transação autorizada
            Notificacao.Notificacao.Criar(Notificacao.Notificacao.NOTIFICACAO_TRANSACAO_AUTORIZADA, "Pagamento Plano: " + plano.Nome, TipoNotificacao.Sistema, this, null);
        }

        private void DesativarAssinaturaAtiva()
        {
            //Caso tenha alguma assintura ativa, deseativa ela
            if (this.Assinaturas.Count > 0 && this.Assinaturas.Any(x => x.Ativo))
            {
                var planoAtivo = this.Assinaturas.FirstOrDefault(x => x.Ativo);
                planoAtivo.Ativo = false;
            }
        }

        private String CriptografarSenha(string senhaAberta)
        {
            SHA256 criptoProvider = SHA256.Create();

            byte[] btexto = Encoding.UTF8.GetBytes(senhaAberta);

            var criptoResult = criptoProvider.ComputeHash(btexto);

            return Convert.ToHexString(criptoResult);
        }
    }
}
