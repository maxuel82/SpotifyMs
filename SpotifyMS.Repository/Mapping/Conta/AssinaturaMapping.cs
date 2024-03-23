using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpotifyMs.Domain.Conta.Agreggates;

namespace SpotifyMS.Repository.Mapping.Conta
{
    public class AssinaturaMapping : IEntityTypeConfiguration<Assinatura>
    {
        public void Configure(EntityTypeBuilder<Assinatura> builder)
        {
            builder.ToTable(nameof(Assinatura));

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Ativo).IsRequired();
            builder.Property(x => x.DataAtivacao).IsRequired();
            builder.Property(x => x.DataInativacao).IsRequired(false);
           
            //hasOner um para um ,  olhe o withMany fica vazio           
            builder.HasOne(x => x.Plano).WithMany();
        }
    }
}
