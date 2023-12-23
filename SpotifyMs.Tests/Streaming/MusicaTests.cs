using SpotifyMs.Domain.Streaming.Aggregates;
using SpotifyMs.Domain.Streaming.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyMS.Tests.Streaming
{
    public class MusicaTests
    {
        [Fact]
        public void DeveCriarMusicaValida()
        {
            // Act (Agir)
            Musica musica = null;

            // Assert (Afirmação)
            Assert.Null(Record.Exception(() => musica = Musica.Criar("Poderoso DEUS", 4)));
        }

        [Fact]
        public void NãoDeveCriarMusicaInvalida()
        {
            //testar nome da musica nullo
            Assert.Throws<Exception>(() =>
                {
                    Musica musica = Musica.Criar(" ", 4);
                });

            Assert.Throws<ArgumentException>(() =>
            {
                Musica musica2 = Musica.Criar("Poderoso DEUS", -1);
            });

        }
    }
}
