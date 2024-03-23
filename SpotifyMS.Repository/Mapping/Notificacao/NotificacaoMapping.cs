using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SpotifyMS.Repository.Mapping.Notificacao
{
    public class NotificacaoMapping : IEntityTypeConfiguration<SpotifyMs.Domain.Notificacao.Notificacao>
    {
        public void Configure(EntityTypeBuilder<SpotifyMs.Domain.Notificacao.Notificacao> builder)
        {
            builder.ToTable(nameof(SpotifyMs.Domain.Notificacao.Notificacao));

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.DataNotificacao).IsRequired();
            builder.Property(x => x.Mensagem).IsRequired().HasMaxLength(250);
            builder.Property(x => x.Titulo).IsRequired().HasMaxLength(150);
            builder.Property(x => x.TipoNotificacao).IsRequired();

            builder.HasOne(X => X.UsuarioDestino).WithMany(x => x.Notificacoes).IsRequired().OnDelete(DeleteBehavior.Cascade);
            
            builder.HasOne(X => X.UsuarioRemetente).WithMany().IsRequired(false);           
        }
    }  
}
