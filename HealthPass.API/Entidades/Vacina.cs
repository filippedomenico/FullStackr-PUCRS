using HealthPass.API.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthPass.API.Entidades
{
    public class Vacina
    {
        public Vacina(Guid vacinaId, string nome, TipoVacinaEnum tipoVacina, int dosesNecessarias)
        {
            VacinaId = vacinaId;
            Nome = nome;
            DosesNecessarias = dosesNecessarias;
            TipoVacina = tipoVacina;
        }

        public Guid VacinaId { get; private set; }
        public string Nome { get; private set; }
        public int DosesNecessarias { get; private set; }
        public TipoVacinaEnum TipoVacina { get; set; }
        public bool Disponivel { get; private set; } = true;

        public Vacina Inativar()
        {
            this.Disponivel = false;
            return this;
        }

        public ICollection<UsuarioVacina> UsuarioVacinas { get; private set; }

        public Vacina SetarNome(string nome)
        {
            Nome = nome;
            return this;
        }

        public Vacina SetarDisponibilidade(bool disponivel)
        {
            Disponivel = disponivel;
            return this;
        }
    }
}
