using HealthPass.API.Entidades;
using HealthPass.API.ViewModels.Negocio;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HealthPass.API.Interfaces.Negocio
{
    public interface IUsuarioNegocio
    {
        Task<Usuario> Adicionar(Usuario usuario);
        Task<Usuario> Atualizar(Usuario usuario);
        Task<List<Usuario>> Listar();
        Task<Usuario> Obter(Guid usuarioId);
        Task<ListarUsuarioComVacinasNegocioResponse> ObterComVacinas(Guid usuarioId);
        Task<ListarUsuarioComVacinaNegocioResponse> ObterComVacina(Guid usuarioId, Guid vacinaId);
        Task<ListarUsuarioComVacinaNegocioResponse> Vacinar(VacinarUsuarioNegocioRequest request);
    }
}