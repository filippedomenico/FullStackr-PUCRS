using HealthPass.API.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HealthPass.API.Persistencia.Mappings
{
    public class UsuarioConfig : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(prop => prop.UsuarioId);

            builder.Property(prop => prop.CPF)
                .HasMaxLength(11)
                .IsRequired();

            builder.Property(prop => prop.Nome)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(prop => prop.DataNascimento)
                .IsRequired();

            builder.Property(prop => prop.Email)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(prop => prop.Genero)
                .HasColumnType("int")
                .IsRequired();

            builder.Property(prop => prop.Passaporte)
                .HasMaxLength(8)
                .IsRequired();
        }
    }
}
