using HealthPass.API.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace HealthPass.API.Persistencia.Mappings
{
    public class UsuarioDoseVacinaConfig : IEntityTypeConfiguration<UsuarioDoseVacina>
    {
        public void Configure(EntityTypeBuilder<UsuarioDoseVacina> builder)
        {
            builder.HasKey(prop => prop.UsuarioDoseVacinaId);

            builder.HasOne(prop => prop.UsuarioVacina)
                .WithMany(prop => prop.UsuarioDosesVacina)
                .HasForeignKey(prop => prop.UsuarioVacinaId)
                .IsRequired() ;

            builder.Property(prop => prop.DataPrevisaoDose);
        }
    }
}
