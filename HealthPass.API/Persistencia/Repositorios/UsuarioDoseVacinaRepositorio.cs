using HealthPass.API.Entidades;
using HealthPass.API.Interfaces.Persistencia.Repositorios;
using HealthPass.API.Persistencia.Contexto;
using HealthPass.API.Persistencia.Repositorios.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthPass.API.Persistencia.Repositorios
{
    public class UsuarioDoseVacinaRepositorio : RepositorioBase<UsuarioDoseVacina>, IUsuarioDoseVacinaRepositorio
    {
        public UsuarioDoseVacinaRepositorio(ApplicationDbContext context) : base(context)
        {
        }

        public async Task Adicionar(List<UsuarioDoseVacina> doses)
        {
            await DbSet.AddRangeAsync(doses);
        }

        public async Task<UsuarioDoseVacina> Obter(Guid usuarioDoseVacinaId)
        {
            return await DbSet.FindAsync(usuarioDoseVacinaId);
        }

        public async Task<List<UsuarioDoseVacina>> ListarPorUsuarioVacina(Guid usuarioVacinaId)
        {
            return await DbSet.Where(x => x.UsuarioVacinaId == usuarioVacinaId).ToListAsync();
        }

        public async Task<List<UsuarioDoseVacina>> ListarPorUsuarioVacina(List<Guid> usuarioVacinaIds)
        {
            return await DbSet.Where(x => usuarioVacinaIds.Contains(x.UsuarioVacinaId)).ToListAsync();
        }

        public void Atualizar(UsuarioDoseVacina doseVacina)
        {
            DbSet.Update(doseVacina);
        }
    }
}
