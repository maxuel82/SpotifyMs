using SpotifyMs.Domain.Transacao.Agreggates;
using SpotifyMs.Domain.Transacao.ValueObject;

namespace SpotifyMS.Tests.Transacao
{
    public class CartaoTests
    {
        [Fact]
        public void DeveCriarTransacaoComSucesso()
        {
            Cartao cartao = new Cartao()
            {
                Id = Guid.NewGuid(),
                Ativo = true,
                Limite = 1000M,
                Numero = "5512355123"
            };

            var comerciante = new Comerciante()
            {
                Nome = "PagSeguro"
            };

            cartao.CriarTransacao(comerciante, 25M, "PagSeguro Transacao");
            Assert.True(cartao.Transacoes.Count > 0);
            Assert.True(cartao.Limite == 975M);
        }

        [Fact]
        public void CartaoNaoAtivo()
        {
            Cartao cartao = new Cartao()
            {
                Id = Guid.NewGuid(),
                Ativo = false,
                Limite = 1000M,
                Numero = "6465465466"
            };

            var comerciante = new Comerciante()
            {
                Nome = "PagSeguro"
            };

            Assert.Throws<Exception>(
                () => cartao.CriarTransacao(comerciante, 19M, "PagSeguro Transacao"));
        }

        [Fact]
        public void LimiteInsuficiente()
        {
            Cartao cartao = new Cartao()
            {
                Id = Guid.NewGuid(),
                Ativo = true,
                Limite = 10M,
                Numero = "6465465466"
            };

            var comerciante = new Comerciante()
            {
                Nome = "PagSeguro"
            };

            Assert.Throws<Exception>(
                () => cartao.CriarTransacao(comerciante, 19M, "PagSeguro Transacao"));
        }

        [Fact]
        public void TransacaoDuplicada()
        {
            Cartao cartao = new Cartao()
            {
                Id = Guid.NewGuid(),
                Ativo = true,
                Limite = 1000M,
                Numero = "1234554321"
            };

            var comerciante = new Comerciante()
            {
                Nome = "PagSeguro"
            };

            cartao.CriarTransacao(comerciante, 19M, "PagSeguro ativacao xpto");

            Assert.Throws<Exception>(
                () => cartao.CriarTransacao(comerciante, 19M, "PagSeguro ativacao xpto2"));
        }

        [Fact]
        public void AltaFrequenciaPequenoIntervalo()
        {
            Cartao cartao = new Cartao()
            {
                Id = Guid.NewGuid(),
                Ativo = true,
                Limite = 1000M,
                Numero = "6465465466"
            };

                            
            cartao.Transacoes.Add(new SpotifyMs.Domain.Transacao.Agreggates.Transacao()
            {
                DtTransacao = DateTime.Now.AddMinutes(-1),
                Id = Guid.NewGuid(),
                Comerciante = new Comerciante() { Nome = "PagSeguro1" },
                Valor = 16M,
                Descricao = "PagSeguro ativacao xpto1"
            });

            cartao.Transacoes.Add(new SpotifyMs.Domain.Transacao.Agreggates.Transacao()
            {
                DtTransacao = DateTime.Now.AddMinutes(-0.5),
                Id = Guid.NewGuid(),
                Comerciante = new Comerciante() { Nome = "PagSeguro2" },
                Valor = 17M,
                Descricao = "PagSeguro ativacao xpto2"
            });

            cartao.Transacoes.Add(new SpotifyMs.Domain.Transacao.Agreggates.Transacao()
            {
                DtTransacao = DateTime.Now,
                Id = Guid.NewGuid(),
                Comerciante = new Comerciante() { Nome = "PagSeguro3" },
                Valor = 18M,
                Descricao = "PagSeguro ativacao xpto2"
            });


            var comerciante = new Comerciante()
            {
                Nome = "PagSeguro4"
            };

            Assert.Throws<Exception>(
                () => cartao.CriarTransacao(comerciante, 19M, "PagSeguro ativacao xpto4"));
        }

        [Fact]
        public void CartaoInvalido()
        {
            var comerciante = new Comerciante()
            {
                Nome = "PagSeguro"
            };

            //cartao numero com espaços vazios
            Cartao cartao = new Cartao()
            {
                Id = Guid.NewGuid(),
                Ativo = true,
                Limite = 1000M,
                Numero = "     "
            };

            Assert.Throws<Exception>(
                () => cartao.CriarTransacao(comerciante, 19M, "PagSeguro Transacao cartão apenas com com espaço no numero"));

            //cartao numero nullo
            Cartao cartao2 = new Cartao()
            {
                Id = Guid.NewGuid(),
                Ativo = true,
                Limite = 1000M,
                Numero = null
            };

            Assert.Throws<Exception>(
                () => cartao2.CriarTransacao(comerciante, 19M, "PagSeguro Transacao cartão sem numero informado"));


            //cartao numero nullo invalido contendo letras
            Cartao cartao3 = new Cartao()
            {
                Id = Guid.NewGuid(),
                Ativo = true,
                Limite = 1000M,
                Numero = "ABCDE12345"
            };

            Assert.Throws<Exception>(
                () => cartao3.CriarTransacao(comerciante, 19M, "PagSeguro Transacao cartão com numero invalido"));
        }

    }
}
