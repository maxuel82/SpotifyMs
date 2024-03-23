using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpotifyMs.Domain.Core.ValueObject;
using SpotifyMs.Domain.Transacao.ValueObject;

namespace SpotifyMS.Repository.Mapping.Transacao
{
    public class TransacaoMapping : IEntityTypeConfiguration<SpotifyMs.Domain.Transacao.Agreggates.Transacao>
    {
        public void Configure(EntityTypeBuilder<SpotifyMs.Domain.Transacao.Agreggates.Transacao> builder)
        {
            builder.ToTable(nameof(SpotifyMs.Domain.Transacao.Agreggates.Transacao));

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.DtTransacao).IsRequired();
            builder.Property(x => x.Descricao).IsRequired().HasMaxLength(50);

            builder.OwnsOne<Comerciante>(d => d.Comerciante, c =>
            {
                c.Property(x => x.Nome).HasColumnName("NomeComerciante").IsRequired();
            });

            builder.OwnsOne<Monetario>(d => d.Valor, c =>
            {
                c.Property(x => x.Valor).HasColumnName("ValorTransacao").IsRequired();
            });
        }
    }
}
