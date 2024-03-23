using SpotifyMs.Domain.Core.ValueObject;

namespace SpotifyMs.Domain.Streaming.Aggregates
{
    public class Plano
    {
        public Guid Id { get; private set; }
        public String? Nome { get; private set; }
        public Monetario? Valor { get; private set; }


        public static Plano Criar(string nome, Monetario valor)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new Exception("Informe o nome do plano.");

            return new Plano()
            {
                Id = Guid.NewGuid(),
                Nome = nome,
                Valor = new Monetario(valor),
            };
        }
       
    }
}
