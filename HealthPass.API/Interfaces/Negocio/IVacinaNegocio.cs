using HealthPass.API.Entidades;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HealthPass.API.Negocio
{
    public interface IVacinaNegocio
    {
        Task<Vacina> Adicionar(Vacina vacina);
        Task<Vacina> Alterar(Vacina vacina);
        Task<List<Vacina>> Listar();
        Task<Vacina> Obter(Guid vacinaId);
    }
}