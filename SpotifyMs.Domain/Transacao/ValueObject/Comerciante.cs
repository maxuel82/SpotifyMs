namespace SpotifyMs.Domain.Transacao.ValueObject
{
    public record Comerciante
    {
        public string Nome { get; set; }

        public static Comerciante Criar(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new Exception("Informe o nome do comerciante.");

            return new Comerciante()
            {
                Nome = nome
            };
        }
    }
}
