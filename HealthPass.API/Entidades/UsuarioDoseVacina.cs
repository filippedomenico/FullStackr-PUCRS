using System;
using System.Collections.Generic;

namespace HealthPass.API.Entidades
{
    public class UsuarioDoseVacina
    {
        public UsuarioDoseVacina(Guid usuarioDoseVacinaId,
                                 Guid usuarioVacinaId,
                                 DateTime? dataVacinacao,
                                 DateTime dataPrevisaoDose)
        {
            UsuarioDoseVacinaId = usuarioDoseVacinaId;
            UsuarioVacinaId = usuarioVacinaId;
            DataVacinacao = dataVacinacao;
            DataPrevisaoDose = dataPrevisaoDose;
        }

        public Guid UsuarioDoseVacinaId { get; private set; }
        public Guid UsuarioVacinaId { get; private set; }
        public DateTime? DataVacinacao { get; private set; }
        public DateTime DataPrevisaoDose { get; private set; }

        public UsuarioVacina UsuarioVacina { get; private set; }

        public UsuarioDoseVacina Vacinar()
        {
            DataVacinacao = DateTime.Now.Date;
            return this;
        }

    }
}
