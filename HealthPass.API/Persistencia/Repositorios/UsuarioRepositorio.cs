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
    public class UsuarioRepositorio : RepositorioBase<Usuario>, IUsuarioRepositorio
    {
        public UsuarioRepositorio(ApplicationDbContext context) : base(context)
        {

        }

        public async Task Adicionar(Usuario usuario)
        {
            await DbSet.AddAsync(usuario);
        }

        public void Atualizar(Usuario usuario)
        {
            DbSet.Update(usuario);
        }

        public async Task<Usuario> Obter(Guid usuarioId, bool incluirVacina = false, bool incluirDoses = false)
        {
            var query = DbSet.AsQueryable();

            if (incluirVacina)
                query = query.Include(x => x.UsuarioVacinas).ThenInclude(x => x.Vacina);

            if (incluirDoses)
                query = query.Include(x => x.UsuarioVacinas)
                             .ThenInclude(x => x.Vacina)
                             .Include(x => x.UsuarioVacinas)
                             .ThenInclude(x => x.UsuarioDosesVacina);
                             

            return await query.FirstOrDefaultAsync(x => x.UsuarioId == usuarioId);

        }

        public async Task<List<Usuario>> Listar(bool incluirVacina = false, bool incluirDoses = false)
        {
            var query = DbSet.AsQueryable();

            if (incluirVacina)
                query = query.Include(x => x.UsuarioVacinas);

            if (incluirDoses)
                query = query.Include(x => x.UsuarioVacinas)
                             .ThenInclude(x => x.UsuarioDosesVacina);

            return await query.ToListAsync();
        }
    }
}
