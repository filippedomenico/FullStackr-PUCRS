using HealthPass.API.Entidades;
using HealthPass.API.Interfaces.Persistencia.Repositorios;
using HealthPass.API.Persistencia.Contexto;
using HealthPass.API.Persistencia.Repositorios.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace HealthPass.API.Persistencia.Repositorios
{
    public class UsuarioVacinaRepositorio : RepositorioBase<UsuarioVacina>, IUsuarioVacinaRepositorio
    {
        public UsuarioVacinaRepositorio(ApplicationDbContext context) : base(context)
        {
        }

        public async Task Adicionar(UsuarioVacina usuarioVacina)
        {
            await DbSet.AddAsync(usuarioVacina);
        }

        public void Atualizar(UsuarioVacina usuarioVacina)
        {
            DbSet.Update(usuarioVacina);
        }

        public async Task<UsuarioVacina> Obter(Guid usuarioId, Guid vacinaId, bool carregarUsuario = false, bool carregarVacina = false, bool carregarDoses = false)
        {
            var query = DbSet.Where(x => x.UsuarioId == usuarioId && x.VacinaId == vacinaId);

            if (carregarUsuario)
                query = query.Include(x => x.Usuario);

            if (carregarVacina)
                query = query.Include(x => x.Vacina);

            if(carregarDoses)
                query = query.Include(x => x.UsuarioDosesVacina);

            return await query.FirstOrDefaultAsync();
        }
    }
}
