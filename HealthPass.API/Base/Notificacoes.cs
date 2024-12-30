using HealthPass.API.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthPass.API.Base
{
    public class Notificacoes : INotificacoes
    {
        public List<string> Mensagens { get; set; } = new List<string>();

        public void AdicionarMensagem(string mensagem)
        {
            Mensagens.Add(mensagem);
        }
    }
}
