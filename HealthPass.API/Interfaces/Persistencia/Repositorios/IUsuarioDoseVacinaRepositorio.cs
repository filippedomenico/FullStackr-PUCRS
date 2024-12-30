using HealthPass.API.Entidades;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HealthPass.API.Interfaces.Persistencia.Repositorios
{
    public interface IUsuarioDoseVacinaRepositorio
    {
        Task Adicionar(List<UsuarioDoseVacina> doses);
        Task<List<UsuarioDoseVacina>> ListarPorUsuarioVacina(Guid usuarioVacinaId);
        Task<List<UsuarioDoseVacina>> ListarPorUsuarioVacina(List<Guid> usuarioVacinaIds);
        Task<UsuarioDoseVacina> Obter(Guid usuarioDoseVacinaId);
        void Atualizar(UsuarioDoseVacina doseVacina);
    }
}