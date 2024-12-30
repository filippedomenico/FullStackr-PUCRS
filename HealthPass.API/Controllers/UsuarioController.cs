using HealthPass.API.Entidades;
using HealthPass.API.Interfaces.Base;
using HealthPass.API.Interfaces.Negocio;
using HealthPass.API.Interfaces.Persistencia;
using HealthPass.API.ViewModels.API.Usuario.Adicionar;
using HealthPass.API.ViewModels.API.Usuario.Atualizar;
using HealthPass.API.ViewModels.API.Usuario.Lister;
using HealthPass.API.ViewModels.API.Usuario.Obter;
using HealthPass.API.ViewModels.API.Usuario.ObterComVacina;
using HealthPass.API.ViewModels.API.Usuario.ObterComVacinas;
using HealthPass.API.ViewModels.API.Usuario.Vacinar;
using HealthPass.API.ViewModels.Negocio;
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
    public class UsuarioController : BaseController
    {
        private readonly IUsuarioNegocio _usuarioNegocio;

        public UsuarioController(IUnitOfWork unitOfWork, INotificacoes notificacoes, IUsuarioNegocio usuarioNegocio) : base(unitOfWork, notificacoes)
        {
            _usuarioNegocio = usuarioNegocio;
        }

        [HttpPost]
        public async Task<IActionResult> Adicionar([FromBody] AdicionarUsuarioRequest request)
        {
            Usuario usuario = await _usuarioNegocio.Adicionar(new Usuario(Guid.NewGuid(), request.CPF, request.Nome,
                                                                    request.DataNascimento, request.Email, request.Genero, request.Passaporte));

            return await RetornarDado(() => new AdicionarUsuarioResponse
            {
                UsuarioId = usuario.UsuarioId,
                CPF = usuario.CPF,
                Nome = usuario.Nome,
                DataNascimento = usuario.DataNascimento,
                Email = usuario.Email,
                Genero = usuario.Genero,
                Passaporte = usuario.Passaporte
            });
        }

        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            List<Usuario> usuarios = await _usuarioNegocio.Listar();

            return await RetornarDado(() => new ListarUsuariosResponse
            {
                Usuarios = usuarios.Select(x => new ListarUsuariosResponseItem
                {
                    UsuarioId = x.UsuarioId,
                    CPF = x.CPF,
                    Nome = x.Nome,
                    DataNascimento = x.DataNascimento,
                    Email = x.Email,
                    Genero = x.Genero,
                    Passaporte = x.Passaporte
                }).ToList()
            });
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Obter([FromRoute] Guid id)
        {
            Usuario usuario = await _usuarioNegocio.Obter(id);

            return await RetornarDado(() => new ObterUsuarioResponse
            {
                UsuarioId = usuario.UsuarioId,
                CPF = usuario.CPF,
                Nome = usuario.Nome,
                DataNascimento = usuario.DataNascimento,
                Email = usuario.Email,
                Genero = usuario.Genero,
                Passaporte = usuario.Passaporte
            });
        }

        [HttpPut]
        [Route("{usuarioId}")]
        public async Task<IActionResult> Atualizar([FromRoute] Guid usuarioId, AtualizarUsuarioRequest request)
        {
            Usuario usuario = await _usuarioNegocio.Atualizar(new Usuario(usuarioId, request.CPF, request.Nome,
                                                                   request.DataNascimento, request.Email, request.Genero, request.Passaporte));

            return await RetornarDado(() => new AtualizarUsuarioResponse
            {
                UsuarioId = usuario.UsuarioId,
                CPF = usuario.CPF,
                Nome = usuario.Nome,
                DataNascimento = usuario.DataNascimento,
                Email = usuario.Email,
                Genero = usuario.Genero,
                Passaporte = usuario.Passaporte
            });
        }

        [HttpGet]
        [Route("{usuarioId}/Vacinas")]
        public async Task<IActionResult> ObterComVacinas([FromRoute] Guid usuarioId)
        {
            ListarUsuarioComVacinasNegocioResponse usuario = await _usuarioNegocio.ObterComVacinas(usuarioId);

            return await RetornarDado(() => new ObterComVacinasResponse
            {
                UsuarioId = usuario.UsuarioId,
                CPF = usuario.CPF,
                Nome = usuario.Nome,
                DataNascimento = usuario.DataNascimento,
                Email = usuario.Email,
                Genero = usuario.Genero,
                Passaporte = usuario.Passaporte,
                Vacinas = usuario.Vacinas.Select(x => new ObterComVacinasResponseVacina
                {
                    VacinaId = x.VacinaId,
                    Nome = x.Nome,
                    TipoVacina = x.TipoVacina,
                    DosesNecessarias = x.DosesNecessarias,
                    DosesAplicadoas = x.DosesAplicadoas,
                    ComVacinaValida = x.ComVacinaValida
                }).ToList()
            });
        }

        [HttpGet]
        [Route("{usuarioId}/Vacina/{vacinaId}")]
        public async Task<IActionResult> ObterComVacina([FromRoute] Guid usuarioId, [FromRoute] Guid vacinaId)
        {
            var usuarioVacina = await _usuarioNegocio.ObterComVacina(usuarioId, vacinaId);

            return await RetornarDado(() => new ObterComVacinaResponse
            {
                UsuarioId = usuarioVacina.UsuarioId,
                CPF = usuarioVacina.CPF,
                Nome = usuarioVacina.Nome,
                DataNascimento = usuarioVacina.DataNascimento,
                Email = usuarioVacina.Email,
                Genero = usuarioVacina.Genero,
                Passaporte = usuarioVacina.Passaporte,
                Vacina = new ObterComVacinaResponseVacina
                {
                    VacinaId = usuarioVacina.Vacina.VacinaId,
                    Nome = usuarioVacina.Vacina.Nome,
                    TipoVacina = usuarioVacina.Vacina.TipoVacina,
                    DosesNecessarias = usuarioVacina.Vacina.DosesNecessarias,
                    DosesAplicadoas = usuarioVacina.Vacina.DosesAplicadoas,
                    ComVacinaValida = usuarioVacina.Vacina.ComVacinaValida,
                    Doses = usuarioVacina.Vacina.Doses.Select(x => new ObterComVacinaResponseDosesVacina
                    {
                        DataPrevisaoDose = x.DataPrevisaoDose,
                        DataVacinacao = x.DataVacinacao
                    }).ToList()
                }
            });
        }

        [HttpPut]
        [Route("{usuarioId}/Vacinar")]
        public async Task<IActionResult> Vacinar([FromRoute] Guid usuarioId, VacinarUsuarioRequest request)
        {
            var usuarioVacina = await _usuarioNegocio.Vacinar(new VacinarUsuarioNegocioRequest(usuarioId, request.VacinaId, request.ProximasDatas));

            return await RetornarDado(() => new VacinarUsuarioResponse
            {
                UsuarioId = usuarioVacina.UsuarioId,
                CPF = usuarioVacina.CPF,
                Nome = usuarioVacina.Nome,
                DataNascimento = usuarioVacina.DataNascimento,
                Email = usuarioVacina.Email,
                Genero = usuarioVacina.Genero,
                Passaporte = usuarioVacina.Passaporte,
                Vacina = new VacinarUsuarioResponseVacina
                {
                    VacinaId = usuarioVacina.Vacina.VacinaId,
                    Nome = usuarioVacina.Vacina.Nome,
                    TipoVacina = usuarioVacina.Vacina.TipoVacina,
                    DosesNecessarias = usuarioVacina.Vacina.DosesNecessarias,
                    DosesAplicadoas = usuarioVacina.Vacina.DosesAplicadoas,
                    ComVacinaValida = usuarioVacina.Vacina.ComVacinaValida,
                    Doses = usuarioVacina.Vacina.Doses.Select(x => new VacinarUsuarioDosesResponse
                    {
                        DataPrevisaoDose = x.DataPrevisaoDose,
                        DataVacinacao = x.DataVacinacao
                    }).ToList()
                }
            });
        }

    }
}
