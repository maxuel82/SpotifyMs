using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpotifyMs.Domain.Conta.Agreggates;

namespace SpotifyMS.Repository.Mapping.Conta
{
    public class UsuarioMapping : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable(nameof(Usuario));

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(150);
            builder.Property(x => x.Senha).IsRequired().HasMaxLength(100);
            builder.Property(x => x.DtNascimento).IsRequired();

            //Relacionamentos
               /*varios cartoes*/
            builder.HasMany(x => x.Cartoes).WithOne();
            builder.HasMany(x => x.Assinaturas).WithOne();
            builder.HasMany(x => x.Playlists).WithOne(x => x.Usuario);

            /* Atenção não precisar ter esse mapeamento pois já existe na notificações...
             builder.HasMany(x => x.Notificacoes).WithOne(x => x.UsuarioDestino);  */
        }
    }
}
