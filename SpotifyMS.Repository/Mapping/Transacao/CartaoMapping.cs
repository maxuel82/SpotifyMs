using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpotifyMs.Domain.Core.ValueObject;
using SpotifyMs.Domain.Transacao.Agreggates;

namespace SpotifyMS.Repository.Mapping.Transacao
{
    public class CartaoMapping : IEntityTypeConfiguration<Cartao>
    {
        public void Configure(EntityTypeBuilder<Cartao> builder)
        {
            builder.ToTable(nameof(Cartao));

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Ativo).IsRequired();
            builder.Property(x => x.Numero).IsRequired().HasMaxLength(100);

            builder.OwnsOne<Monetario>(d => d.Limite, c =>
            {
                c.Property(x => x.Valor).HasColumnName("Limite").IsRequired();
            });

            builder.HasMany(x => x.Transacoes).WithOne();

        }
    }
}
