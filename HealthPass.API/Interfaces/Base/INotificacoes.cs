using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthPass.API.Interfaces.Base
{
    public interface INotificacoes
    {
        public List<string> Mensagens { get; set; }

        public void AdicionarMensagem(string mensagem);
    }
}
