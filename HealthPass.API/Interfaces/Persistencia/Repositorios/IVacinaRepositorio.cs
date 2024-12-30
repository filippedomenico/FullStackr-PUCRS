using HealthPass.API.Entidades;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HealthPass.API.Interfaces.Persistencia.Repositorios
{
    public interface IVacinaRepositorio
    {
        Task Adicionar(Vacina vacina);
        void Atualizar(Vacina vacina);
        Task<List<Vacina>> Listar();
        Task<Vacina> Obter(Guid VacinaId);
    }
}
