using SpotifyMs.Domain.Conta.Agreggates;
using SpotifyMs.Domain.Streaming.Aggregates;

namespace SpotifyMS.Tests.Domain
{
    public class AssinaturaTests
    {

        [Fact]
        public void DeveCriarAssinaturaValida()
        {
            // Act (Agir)
            Assinatura assinaura = null;
            Plano plano = Plano.Criar("Plano prêmio", 19.90M);
            // Assert (Afirmação)
            Assert.Null(Record.Exception(() => assinaura = Assinatura.Criar(plano)));
        }

        [Fact]
        public void NaoDeveCriarAssinaturaInvalida()
        {
            //testar nome da musica nullo
            Assert.Throws<Exception>(() =>
            {
                Assinatura assinaura = Assinatura.Criar(null);
            });
        }
        
        [Fact]
        public void InativarAssinaturaComSucesso()
        {
            // Act (Agir)
            Assinatura assinatura = null;
            Plano plano = Plano.Criar("Plano prêmio", 19.90M);
            
            // Assert (Afirmação)
            assinatura = Assinatura.Criar(plano);

            Assert.Null(Record.Exception(() => assinatura.InativarAssinatura() ));   
        }

        [Fact]
        public void InativarAssinaturaSemSucesso()
        {
            // Act (Agir)
            Assinatura assinatura = null;
            Plano plano = Plano.Criar("Plano prêmio", 19.90M);

            // Assert (Afirmação)
            assinatura = Assinatura.Criar(plano);

            //executar a assinatura, para que na segunda execução ocorra a tratativa do erro
            Assert.Null(Record.Exception(() => assinatura.InativarAssinatura()));
            
            //executando pela segunda vez para forçar o erro no metodo            
            Assert.Throws<Exception>(() =>
            {
                assinatura.InativarAssinatura();
            });
        }

    }
}
