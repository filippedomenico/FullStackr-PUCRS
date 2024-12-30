using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthPass.API.ViewModels.API.Usuario.Vacinar
{
    public class VacinarUsuarioRequest
    {
        public Guid VacinaId { get; set; }
        public List<DateTime> ProximasDatas { get; set; }
    }
}
