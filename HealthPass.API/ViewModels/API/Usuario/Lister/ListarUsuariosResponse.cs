using HealthPass.API.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthPass.API.ViewModels.API.Usuario.Lister
{
    public class ListarUsuariosResponse
    {
        public List<ListarUsuariosResponseItem> Usuarios { get; set; }
    }

    public class ListarUsuariosResponseItem
    {
        public Guid UsuarioId { get; set; }
        public string CPF { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; }
        public GeneroEnum Genero { get; set; }
        public string Passaporte { get; set; }
    }
}
