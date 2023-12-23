using SpotifyMs.Domain.Core.ValueObject;
using SpotifyMs.Domain.Transacao.ValueObject;

namespace SpotifyMs.Domain.Transacao.Agreggates
{
    public class Cartao
    {
        private const int INTERVALO_TRANSACAO = -2;
        private const int REPETICAO_TRANSACAO = 1;

        public Guid Id { get; set; }
        public Boolean Ativo { get; set; }
        public Monetario Limite { get; set; }
        public String Numero { get; set; }
        public List<Transacao> Transacoes { get; set; } = new List<Transacao>();

        public void CriarTransacao(Comerciante comerciante, Monetario valor, string Descricao = "")
        {
            
            //Verificar se o cartão está ativo
            this.IsCartaoAtivo();

            //verifica se o cartaço de credito é valido
            this.IsCartaoValido();

            Transacao transacao = new Transacao();
            transacao.Comerciante = comerciante;
            transacao.Valor = valor;
            transacao.Descricao = Descricao;
            transacao.DtTransacao = DateTime.Now;

            //Verifica limite disponivel
            this.VerificaLimite(transacao);
            
            //Verifica regras antifraude
            this.ValidarTransacao(transacao);

            //Cria numero de autorização
            transacao.Id = Guid.NewGuid();

            //Diminui o limite com o valor da transacao
            this.Limite = this.Limite - transacao.Valor;

            this.Transacoes.Add(transacao);
                
        }

        private void ValidarTransacao(Transacao transacao)
        {
            //alta-frequência-pequeno-intervalo
            var ultimasTransacoes = this.Transacoes.Where(x => 
                                                          x.DtTransacao >= DateTime.Now.AddMinutes(INTERVALO_TRANSACAO));
            
            if (ultimasTransacoes?.Count() >= 3)
                throw new Exception("Cartão utilizado em alta frequência em pequeno intervalo.");

            //transação duplicada
            var transacaoRepetidaPorComerciante = ultimasTransacoes?
                                                .Where(x => x.Comerciante.Nome.ToUpper() == transacao.Comerciante.Nome.ToUpper()
                                                       && x.Valor == transacao.Valor)
                                                .Count() == REPETICAO_TRANSACAO;

            if (transacaoRepetidaPorComerciante)
                throw new Exception("Cartão utilizado em transação duplicada.");

        }

        private void VerificaLimite(Transacao transacao)
        {
            //limite insuficiente
            if (this.Limite < transacao.Valor)
                throw new Exception("Cartão não possui limite para esta transacao");
        }

        private void IsCartaoAtivo()
        {
            if (this.Ativo == false)
                throw new Exception("Cartão não está ativo");
        }
        private void IsCartaoValido()
        {
            if (string.IsNullOrWhiteSpace(this.Numero))
            {
                throw new Exception("informe o numero de cartão");
            }
            else if (!long.TryParse(this.Numero, out _))
                throw new Exception("Numero cartão invalido");
        }

    }
}
