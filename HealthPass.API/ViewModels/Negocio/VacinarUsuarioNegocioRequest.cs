using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthPass.API.ViewModels.Negocio
{
    public class VacinarUsuarioNegocioRequest
    {
        public VacinarUsuarioNegocioRequest(Guid usuarioId, Guid vacinaId, List<DateTime> previsoes)
        {
            UsuarioId = usuarioId;
            VacinaId = vacinaId;
            Previsoes = previsoes;
        }

        public Guid UsuarioId { get; private set; }
        public Guid VacinaId { get; private set; }
        public List<DateTime> Previsoes { get; private set; }
    }
}
