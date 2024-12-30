using HealthPass.API.Entidades;
using HealthPass.API.Interfaces.Base;
using HealthPass.API.Interfaces.Persistencia;
using HealthPass.API.Negocio;
using HealthPass.API.ViewModels.API.Vacina.AdicionarVacina;
using HealthPass.API.ViewModels.API.Vacina.AtualizarVacina;
using HealthPass.API.ViewModels.API.Vacina.ListarVacinas;
using HealthPass.API.ViewModels.API.Vacina.ObterVacina;
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
    public class VacinaController : BaseController
    {
        private readonly IVacinaNegocio _vacinaNegocio;

        public VacinaController(IUnitOfWork unitOfWork, INotificacoes notificacoes, IVacinaNegocio vacinaNegocio) : base(unitOfWork, notificacoes)
        {
            _vacinaNegocio = vacinaNegocio;
        }

        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            List<Vacina> vacinas = await _vacinaNegocio.Listar();

            return await RetornarDado(() => new ListarVacinasResponse
            {
                Vacinas = vacinas.Select(x => new ListarVacinasResponseItem
                {
                    VacinaId = x.VacinaId,
                    Nome = x.Nome,
                    Disponivel = x.Disponivel,
                    DosesNecessarias = x.DosesNecessarias,
                    TipoVacina = x.TipoVacina
                }).ToList()
            });
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Obter([FromRoute] Guid id)
        {
            Vacina vacina = await _vacinaNegocio.Obter(id);

            return await RetornarDado(() => new ObterVacinaResponse
            {
                VacinaId = vacina.VacinaId,
                Nome = vacina.Nome,
                Disponivel = vacina.Disponivel,
                DosesNecessarias = vacina.DosesNecessarias,
                TipoVacina = vacina.TipoVacina
            });
        }

        [HttpPost]
        public async Task<IActionResult> Adicionar([FromBody] AdicionarVacinaRequest request)
        {
            Vacina vacina = await _vacinaNegocio.Adicionar(new Vacina(Guid.NewGuid(), request.Nome, request.TipoVacina, request.DosesNecessarias));

            return await RetornarDado(() => new AdicionarVacinaResponse
            {
                VacinaId = vacina.VacinaId,
                Nome = vacina.Nome,
                Disponivel = vacina.Disponivel,
                DosesNecessarias = vacina.DosesNecessarias,
                TipoVacina = vacina.TipoVacina

            });
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Atualizar([FromRoute] Guid id, AtualizarVacinaRequest request)
        {
            Vacina vacina = await _vacinaNegocio.Alterar(new Vacina(id, request.Nome, request.TipoVacina, request.DosesNecessarias));

            return await RetornarDado(() => new AtualizarVacinaResponse
            {
                VacinaId = vacina.VacinaId,
                Nome = vacina.Nome,
                Disponivel = vacina.Disponivel,
                DosesNecessarias = vacina.DosesNecessarias,
                TipoVacina = vacina.TipoVacina
            });
        }
    }
}
