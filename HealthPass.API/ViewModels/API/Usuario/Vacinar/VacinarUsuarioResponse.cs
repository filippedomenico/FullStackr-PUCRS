using HealthPass.API.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthPass.API.ViewModels.API.Usuario.Vacinar
{

    public class VacinarUsuarioResponse
    {
        public Guid UsuarioId { get; set; }
        public string CPF { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; }
        public GeneroEnum Genero { get; set; }
        public string Passaporte { get; set; }
        public VacinarUsuarioResponseVacina Vacina { get; set; }
    }

    public class VacinarUsuarioResponseVacina
    {
        public Guid VacinaId { get; set; }
        public string Nome { get; set; }
        public int DosesNecessarias { get; set; }
        public int DosesAplicadoas { get; set; }
        public TipoVacinaEnum TipoVacina { get; set; }
        public bool ComVacinaValida { get; set; }

        public List<VacinarUsuarioDosesResponse> Doses { get; set; }
    }

    public class VacinarUsuarioDosesResponse
    {
        public DateTime? DataVacinacao { get; set; }
        public DateTime DataPrevisaoDose { get; set; }
    }

}
