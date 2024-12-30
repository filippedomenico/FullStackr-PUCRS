using HealthPass.API.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthPass.API.ViewModels.API.Vacina.ListarVacinas
{
    public class ListarVacinasResponse
    {
        public List<ListarVacinasResponseItem> Vacinas { get; set; } = new List<ListarVacinasResponseItem>();
    }

    public class ListarVacinasResponseItem
    {
        public Guid VacinaId { get; set; }
        public string Nome { get; set; }
        public int DosesNecessarias { get; set; }
        public TipoVacinaEnum TipoVacina { get; set; }
        public bool Disponivel { get; set; } = true;
    }
}
