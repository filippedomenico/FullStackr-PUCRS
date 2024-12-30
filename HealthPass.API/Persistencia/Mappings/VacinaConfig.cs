using HealthPass.API.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HealthPass.API.Persistencia.Mappings
{
    public class VacinaConfig : IEntityTypeConfiguration<Vacina>
    {
        public void Configure(EntityTypeBuilder<Vacina> builder)
        {
            builder.HasKey(prop => prop.VacinaId);

            builder.Property(prop => prop.Nome)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(prop => prop.TipoVacina)
                .HasColumnType("int")
                .IsRequired();

            builder.Property(prop => prop.DosesNecessarias)
                .IsRequired();
        }
    }
}
