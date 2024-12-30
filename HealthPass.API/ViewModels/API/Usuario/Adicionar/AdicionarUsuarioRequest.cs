using HealthPass.API.Enums;
using System;

namespace HealthPass.API.ViewModels.API.Usuario.Adicionar
{
    public class AdicionarUsuarioRequest
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
