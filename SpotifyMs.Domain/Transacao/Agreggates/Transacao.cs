using SpotifyMs.Domain.Core.ValueObject;
using SpotifyMs.Domain.Transacao.ValueObject;

namespace SpotifyMs.Domain.Transacao.Agreggates
{
    public class Transacao
    {
        public Guid Id { get; set; }
        public DateTime DtTransacao { get; set; }
        public Monetario Valor { get; set; }
        public String Descricao { get; set; }
        public Comerciante Comerciante { get; set; }
        
    }
}
