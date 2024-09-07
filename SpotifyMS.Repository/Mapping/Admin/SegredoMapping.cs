using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpotifyMS.Domain.Admin;

namespace SpotifyMS.Repository.Mapping.Admin
{
    public class SegredoMapping : IEntityTypeConfiguration<Segredo>
    {
        public void Configure(EntityTypeBuilder<Segredo> builder)
        {
            builder.ToTable(nameof(Segredo));

            builder.HasKey(x => x.Chave);
            builder.Property(x => x.Valor).IsRequired().HasMaxLength(1000);
        }
    }
}