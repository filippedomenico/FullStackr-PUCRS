using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthPass.API.Entidades
{
    public class UsuarioVacina
    {
        public UsuarioVacina(Guid usuarioVacinaId,
                             Guid usuarioId,
                             Guid vacinaId)
        {
            UsuarioVacinaId = usuarioVacinaId;
            UsuarioId = usuarioId;
            VacinaId = vacinaId;
        }

        public Guid UsuarioVacinaId { get; private set; }
        public Guid UsuarioId { get; private set; }
        public Guid VacinaId { get; private set; }


        public Usuario Usuario { get; private set; }
        public Vacina Vacina { get; private set; }

        public List<UsuarioDoseVacina> UsuarioDosesVacina { get; private set; }


        public UsuarioVacina SetarDoses(List<UsuarioDoseVacina> doses)
        {
            UsuarioDosesVacina = doses;
            return this;
        }

    }
}
