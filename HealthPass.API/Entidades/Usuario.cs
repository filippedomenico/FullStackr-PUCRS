using HealthPass.API.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthPass.API.Entidades
{
    public class Usuario
    {
        public Usuario(Guid usuarioId,
                       string cPF,
                       string nome,
                       DateTime dataNascimento,
                       string email,
                       GeneroEnum genero,
                       string passaporte)
        {
            UsuarioId = usuarioId;
            CPF = cPF;
            Nome = nome;
            DataNascimento = dataNascimento;
            Email = email;
            Genero = genero;
            Passaporte = passaporte;
        }

        public Guid UsuarioId { get; private set; }
        public string CPF { get; private set; }
        public string Nome { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public string Email { get; private set; }
        public GeneroEnum Genero { get; private set; }
        public string Passaporte { get; private set; }

        public ICollection<UsuarioVacina> UsuarioVacinas { get; private set; }

        public Usuario SetarNumeroPassaporte(string passaporte)
        {
            Passaporte = passaporte;
            return this;
        }
    }
}
