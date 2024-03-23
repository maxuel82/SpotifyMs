using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpotifyMs.Domain.Streaming.Aggregates;
using SpotifyMs.Domain.Streaming.ValueObject;

namespace SpotifyMS.Repository.Mapping.Streaming
{
    public class MusicaMapping : IEntityTypeConfiguration<Musica>
    {
        public void Configure(EntityTypeBuilder<Musica> builder)
        {
            //dessa forma o Entity vai criar uma tabela no banco Musicas
            builder.ToTable(nameof(Musica));
            
            //exemplose tivesse de passar o nome da tabela já criada no banco
            //builder.ToTable("tbl_musica")

            //mapeando a pk.
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(50);

            //mapeando coluna com converso classe duração.  ond d=duração  c=configuração
            builder.OwnsOne<Duracao>(d => d.Duracao, c =>
            {
                c.Property(x => x.Valor).IsRequired().HasMaxLength(50);
            });

        }
    }
}
