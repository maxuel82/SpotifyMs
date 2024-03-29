using SpotifyMs.Domain.Streaming.Aggregates;

namespace SpotifyMs.Domain.Conta.Agreggates
{
    public class Assinatura
    {
        
        public Guid Id { get; private set; }
        public Boolean Ativo { get; private set; }
        public DateTime DataAtivacao { get; private set; }
        public DateTime? DataInativacao { get; private set; }
        public virtual Plano Plano { get; private set; }


        public static Assinatura Criar(Plano plano)
        {

            if (plano == null)
                throw new Exception("Deve ser passado um plano valido");

            return new Assinatura()
            {
                Id = Guid.NewGuid(),
                Ativo = true,
                DataAtivacao = DateTime.Now,
                Plano = plano
            };
        }

        public void InativarAssinatura()
        {
            if (!Ativo)
              throw new Exception("Assinatura Já encontra-se inativa");

            Ativo = false;
            DataInativacao = DateTime.Now;
        }
    }
}
