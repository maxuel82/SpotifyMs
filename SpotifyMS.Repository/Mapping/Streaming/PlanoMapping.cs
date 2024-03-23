using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpotifyMs.Domain.Core.ValueObject;
using SpotifyMs.Domain.Streaming.Aggregates;
using SpotifyMs.Domain.Streaming.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyMS.Repository.Mapping.Streaming
{
    public class PlanoMapping : IEntityTypeConfiguration<Plano>
    {
        public void Configure(EntityTypeBuilder<Plano> builder)
        {
            builder.ToTable(nameof(Plano));

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(50);

            builder.OwnsOne<Monetario>(d => d.Valor, c =>
            {
                //se quiser passar o nome da coluna
                //c.Property(x => x.Valor).HasColumnName("ValorPlano").IsRequired();
                c.Property(x => x.Valor).IsRequired();
            });

        }
    }   
}
