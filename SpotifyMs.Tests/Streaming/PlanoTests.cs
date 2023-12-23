using SpotifyMs.Domain.Conta.Agreggates;
using SpotifyMs.Domain.Streaming.Aggregates;
using SpotifyMs.Domain.Transacao.Agreggates;

namespace SpotifyMS.Tests.Streaming
{
    public class PlanoTests
    {
        [Fact]
        public void DeveCriarPlanoValido()
        {
            Plano plano = Plano.Criar("Plano prêmio", 19.90M);

            Assert.True(!string.IsNullOrWhiteSpace(plano.Nome));

        }

        [Fact]
        public void NãoDeveCriarPlanoInvalido()
        {
            Assert.Throws<Exception>(() =>
            {
                Plano plano = Plano.Criar("  ", 19.90M);
            });

        }
    }
}
