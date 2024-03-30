namespace SpotifyMs.Domain.Core.ValueObject
{
    public record Monetario
    {
        public decimal Valor { get; set; }

        public static implicit operator decimal(Monetario d) => d.Valor;
        public static implicit operator Monetario(decimal valor) => new Monetario(valor);

        
        public Monetario()
        {
            /*Criado construtor publico, vazio para corrigir erro no mapeamento atomatico na criação do usuario 
            SpotifyMs.Aplication\Conta\UsuarioService.cs  metodo   UsuarioDto Criar*/
        }

        public Monetario(Decimal valor)
        {
            if (valor < 0)
                throw new ArgumentException("Valor monetário não pode ser negativo");

            Valor = valor;
        }

        public string Formatado()
        {
            return $"R$ {Valor.ToString("N2")}";
        }


    }
}
