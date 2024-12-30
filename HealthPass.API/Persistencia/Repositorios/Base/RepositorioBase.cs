using HealthPass.API.Persistencia.Contexto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthPass.API.Persistencia.Repositorios.Base
{
    public class RepositorioBase<TEntity> where TEntity : class
    {
        protected ApplicationDbContext Context;
        protected DbSet<TEntity> DbSet;

        public RepositorioBase(ApplicationDbContext context)
        {
            Context = context;
            DbSet = Context.Set<TEntity>();
        }
    }
}
