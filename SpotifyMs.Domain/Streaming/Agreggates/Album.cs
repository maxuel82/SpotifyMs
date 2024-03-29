namespace SpotifyMs.Domain.Streaming.Aggregates
{
    public class Album
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public virtual IList<Musica> Musica { get; set; } = new List<Musica>();
        

        public void AdicionarMusica(Musica musica) => 
            this.Musica.Add(musica);
			
        //public void AdicionarMusica(List<Musica> musicas) =>
        //    this.Musica.AddRange(musicas);
   
    }
}
