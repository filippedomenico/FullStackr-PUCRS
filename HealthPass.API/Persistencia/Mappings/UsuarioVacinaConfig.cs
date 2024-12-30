using HealthPass.API.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HealthPass.API.Persistencia.Mappings
{
    public class UsuarioVacinaConfig : IEntityTypeConfiguration<UsuarioVacina>
    {
        public void Configure(EntityTypeBuilder<UsuarioVacina> builder)
        {
            builder.HasKey(prop => prop.UsuarioVacinaId);

            builder.HasOne(prop => prop.Vacina)
                .WithMany(prop => prop.UsuarioVacinas)
                .HasForeignKey(prop => prop.VacinaId)
                .IsRequired();

            builder.HasOne(prop => prop.Usuario)
                .WithMany(prop => prop.UsuarioVacinas)
                .HasForeignKey(prop => prop.UsuarioId)
                .IsRequired();
        }
    }
}
