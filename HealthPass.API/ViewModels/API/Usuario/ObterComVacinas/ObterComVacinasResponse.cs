using HealthPass.API.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthPass.API.ViewModels.API.Usuario.ObterComVacinas
{
    public class ObterComVacinasResponse
    {
        public Guid UsuarioId { get; set; }
        public string CPF { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; }
        public GeneroEnum Genero { get; set; }
        public string Passaporte { get; set; }
        public bool ComVacinasValidas { get; set; }

        public List<ObterComVacinasResponseVacina> Vacinas { get; set; } = new List<ObterComVacinasResponseVacina>();
    }

    public class ObterComVacinasResponseVacina
    {
        public Guid VacinaId { get; set; }
        public string Nome { get; set; }
        public int DosesNecessarias { get; set; }
        public int DosesAplicadoas { get; set; }
        public TipoVacinaEnum TipoVacina { get; set; }
        public bool ComVacinaValida { get; set; }
    }
}
