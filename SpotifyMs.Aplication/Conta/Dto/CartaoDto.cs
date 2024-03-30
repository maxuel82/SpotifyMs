namespace SpotifyMs.Aplication.Conta.Dto
{
    public class CartaoDto
    {
        public Guid Id { get; set; }
        public Boolean Ativo { get; set; }
        public Decimal Limite { get; set; }
        public String Numero { get; set; }
       //obs o cartão tem o comerciante, no projdo prof. é merchan
    }
}
