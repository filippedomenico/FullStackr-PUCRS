using HealthPass.API.Entidades;
using HealthPass.API.Interfaces.Persistencia.Repositorios;
using HealthPass.API.Persistencia.Contexto;
using HealthPass.API.Persistencia.Repositorios.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HealthPass.API.Persistencia.Repositorios
{
    public class VacinaRepositorio : RepositorioBase<Vacina>, IVacinaRepositorio
    {
        public VacinaRepositorio(ApplicationDbContext context) : base(context)
        {
        }


        public async Task Adicionar(Vacina vacina)
        {
            await DbSet.AddAsync(vacina);
        }

        public void Atualizar(Vacina vacina)
        {
            DbSet.Update(vacina);
        }

        public async Task<Vacina> Obter(Guid VacinaId)
        {
            return await DbSet.FindAsync(VacinaId);
        }

        public async Task<List<Vacina>> Listar()
        {
            return await DbSet.ToListAsync();
        }
    }
}
