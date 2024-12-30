using HealthPass.API.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthPass.API.ViewModels.API.Vacina.AdicionarVacina
{
    public class AdicionarVacinaResponse
    {
        public Guid VacinaId { get; set; }
        public string Nome { get; set; }
        public int DosesNecessarias { get; set; }
        public TipoVacinaEnum TipoVacina { get; set; }
        public bool Disponivel { get; set; } = true;
    }
}
