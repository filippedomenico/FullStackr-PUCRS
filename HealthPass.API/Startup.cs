using HealthPass.API.Base;
using HealthPass.API.Interfaces.Base;
using HealthPass.API.Interfaces.Negocio;
using HealthPass.API.Interfaces.Persistencia;
using HealthPass.API.Interfaces.Persistencia.Repositorios;
using HealthPass.API.Negocio;
using HealthPass.API.Persistencia;
using HealthPass.API.Persistencia.Contexto;
using HealthPass.API.Persistencia.Repositorios;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthPass.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            string connectionString = Configuration.GetConnectionString("SqLite");
            services.AddDbContext<ApplicationDbContext>(prop => prop.UseSqlite(connectionString));


            //Internals
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<INotificacoes, Notificacoes>();

            //Repositorios
            services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
            services.AddScoped<IVacinaRepositorio, VacinaRepositorio>();
            services.AddScoped<IUsuarioVacinaRepositorio, UsuarioVacinaRepositorio>();
            services.AddScoped<IUsuarioDoseVacinaRepositorio, UsuarioDoseVacinaRepositorio>();

            //Negocio
            services.AddScoped<IUsuarioNegocio, UsuarioNegocio>();
            services.AddScoped<IVacinaNegocio, VacinaNegocio>();


            services.AddControllers().AddNewtonsoftJson();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
