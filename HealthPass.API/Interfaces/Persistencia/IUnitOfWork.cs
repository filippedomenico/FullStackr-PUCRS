using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthPass.API.Interfaces.Persistencia
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
