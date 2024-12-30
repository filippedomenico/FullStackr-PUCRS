using HealthPass.API.Entidades;
using System;
using System.Threading.Tasks;

namespace HealthPass.API.Interfaces.Persistencia.Repositorios
{
    public interface IUsuarioVacinaRepositorio
    {
        Task Adicionar(UsuarioVacina usuarioVacina);
        void Atualizar(UsuarioVacina usuarioVacina);
        Task<UsuarioVacina> Obter(Guid usuarioId, Guid vacinaId, bool carregarUsuario = false, bool carregarVacina = false, bool carregarDoses = false);
    }
}
