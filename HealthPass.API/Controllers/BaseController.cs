using HealthPass.API.Base;
using HealthPass.API.Interfaces.Base;
using HealthPass.API.Interfaces.Persistencia;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthPass.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly INotificacoes _notificacoes;

        public BaseController(IUnitOfWork unitOfWork, INotificacoes notificacoes)
        {
            _unitOfWork = unitOfWork;
            _notificacoes = notificacoes;
        }

        public async Task<IActionResult> RetornarDado<T>(Func<T> response)
        {
            if (_notificacoes.Mensagens.Count != 0)
            {
                return Ok(new
                {
                    Erros = _notificacoes.Mensagens,
                    Sucesso = false
                });
            }

            if (await _unitOfWork.Commit())
            {
                var data = response();
                return Ok(new
                {
                    Data = data,
                    Sucesso = true
                });
            }
            else
            {
                return Ok(new
                {
                    Sucesso = false
                });
            }
        }

        public async Task<IActionResult> RetornarDado()
        {
            if (_notificacoes.Mensagens.Count != 0)
            {
                return Ok(new
                {
                    Erros = _notificacoes.Mensagens,
                    Sucesso = false
                });
            }

            if (await _unitOfWork.Commit())
            {
                return Ok(new
                {
                    Sucesso = true
                });
            }
            else
            {
                return Ok(new
                {
                    Sucesso = false
                });
            }
        }
    }
}
