using HealthPass.API.Interfaces.Persistencia;
using HealthPass.API.Persistencia.Contexto;
using System;
using System.Threading.Tasks;

namespace HealthPass.API.Persistencia
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Commit()
        {
            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
