using HealthPass.API.Entidades;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HealthPass.API.Interfaces.Persistencia.Repositorios
{
    public interface IUsuarioRepositorio
    {
        Task Adicionar(Usuario usuario);
        Task<List<Usuario>> Listar(bool incluirVacina = false, bool incluirDoses = false);
        Task<Usuario> Obter(Guid usuarioId, bool incluirVacina = false, bool incluirDoses = false);
        void Atualizar(Usuario usuario);
    }
}
