using HealthPass.API.Entidades;
using HealthPass.API.Persistencia.Mappings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthPass.API.Persistencia.Contexto
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public Usuario Usuario { get; set; }
        public Vacina Vacina { get; set; }
        public UsuarioVacina UsuarioVacina { get; set; }
        public UsuarioDoseVacina UsuarioDoseVacina { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            modelBuilder.ApplyConfiguration(new UsuarioConfig());
            modelBuilder.ApplyConfiguration(new VacinaConfig());
            modelBuilder.ApplyConfiguration(new UsuarioVacinaConfig());
            modelBuilder.ApplyConfiguration(new UsuarioDoseVacinaConfig());

        }
    }
}
