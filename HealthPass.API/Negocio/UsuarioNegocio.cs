using HealthPass.API.Entidades;
using HealthPass.API.Interfaces.Base;
using HealthPass.API.Interfaces.Negocio;
using HealthPass.API.Interfaces.Persistencia.Repositorios;
using HealthPass.API.ViewModels.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthPass.API.Negocio
{
    public class UsuarioNegocio : IUsuarioNegocio
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly IVacinaRepositorio _vacinaRepositorio;
        private readonly IUsuarioVacinaRepositorio _usuarioVacinaRepositorio;
        private readonly IUsuarioDoseVacinaRepositorio _usuarioDoseVacinaRepositorio;
        private readonly INotificacoes _notificacoes;

        public UsuarioNegocio(IUsuarioRepositorio usuarioRepositorio,
                              IVacinaRepositorio vacinaRepositorio,
                              IUsuarioVacinaRepositorio usuarioVacinaRepositorio,
                              IUsuarioDoseVacinaRepositorio usuarioDoseVacinaRepositorio,
                              INotificacoes notificacoes)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _vacinaRepositorio = vacinaRepositorio;
            _usuarioVacinaRepositorio = usuarioVacinaRepositorio;
            _usuarioDoseVacinaRepositorio = usuarioDoseVacinaRepositorio;
            _notificacoes = notificacoes;
        }

        private bool ValidarUsuario(Usuario usuario)
        {
            if (usuario.Nome.Length > 100)
            {
                _notificacoes.AdicionarMensagem("Nome não pode ter mais de 100 caracteres");
                return false;
            }

            if (usuario.CPF.Length != 11)
            {
                _notificacoes.AdicionarMensagem("CPF deve ter 11 caracteres");
                return false;
            }

            if (usuario.Email.Length > 100)
            {
                _notificacoes.AdicionarMensagem("Email não pode ter mais de 100 caracteres");
                return false;
            }

            if (usuario.Passaporte.Length != 8)
            {
                _notificacoes.AdicionarMensagem("Passaporte deve ter 8 caracteres");
                return false;
            }

            return true;
        }

        public async Task<Usuario> Adicionar(Usuario usuario)
        {
            if (!ValidarUsuario(usuario))
                return null;

            await _usuarioRepositorio.Adicionar(usuario);

            return usuario;
        }

        public async Task<Usuario> Atualizar(Usuario usuario)
        {
            if (!ValidarUsuario(usuario))
                return null;

            Usuario usuarioParaAtualizar = await _usuarioRepositorio.Obter(usuario.UsuarioId);
            if (usuarioParaAtualizar == null)
                return null;

            usuarioParaAtualizar.SetarNumeroPassaporte(usuario.Passaporte);

            _usuarioRepositorio.Atualizar(usuarioParaAtualizar);

            return usuario;

        }

        public async Task<Usuario> Obter(Guid usuarioId)
        {
            Usuario usuario = await _usuarioRepositorio.Obter(usuarioId);
            if (usuario == null)
                return null;

            return usuario;
        }

        public async Task<ListarUsuarioComVacinasNegocioResponse> ObterComVacinas(Guid usuarioId)
        {
            Usuario usuario = await _usuarioRepositorio.Obter(usuarioId, true, true);
            if (usuario == null)
                return null;

            ListarUsuarioComVacinasNegocioResponse usuarioComVacinas = new ListarUsuarioComVacinasNegocioResponse
            {
                UsuarioId = usuario.UsuarioId,
                CPF = usuario.CPF,
                Nome = usuario.Nome,
                DataNascimento = usuario.DataNascimento,
                Email = usuario.Email,
                Genero = usuario.Genero,
                Passaporte = usuario.Passaporte,
                Vacinas = usuario.UsuarioVacinas.Select(x => new ListarUsuarioComVacinasNegocioResponseVacina
                {
                    VacinaId = x.VacinaId,
                    Nome = x.Vacina.Nome,
                    TipoVacina = x.Vacina.TipoVacina,
                    DosesNecessarias = x.Vacina.DosesNecessarias,
                    DosesAplicadoas = x.UsuarioDosesVacina.Count(x => x.UsuarioVacinaId == x.UsuarioDoseVacinaId && x.DataVacinacao != null),
                    ComVacinaValida = !x.UsuarioDosesVacina.Any(x => x.DataPrevisaoDose <= DateTime.Now && x.DataVacinacao == null)
                }).ToList()
            };

            usuarioComVacinas.ComVacinasValidas = usuarioComVacinas.Vacinas.Any(x => x.ComVacinaValida == false);

            return usuarioComVacinas;

        }

        public async Task<ListarUsuarioComVacinaNegocioResponse> ObterComVacina(Guid usuarioId, Guid vacinaId)
        {
            Usuario usuario = await _usuarioRepositorio.Obter(usuarioId, true, true);
            if (usuario == null)
            {
                _notificacoes.AdicionarMensagem("Usuario não encontrado");
                return null;
            }

            UsuarioVacina usuarioVacina = await _usuarioVacinaRepositorio.Obter(usuarioId, vacinaId, true, true, true);

            if(usuarioVacina == null)
            {
                _notificacoes.AdicionarMensagem("Esse usuário ainda não tomou esta vacina");
                return null;
            }

            ListarUsuarioComVacinaNegocioResponse usuarioComVacinas = new ListarUsuarioComVacinaNegocioResponse
            {
                UsuarioId = usuarioVacina.Usuario.UsuarioId,
                CPF = usuarioVacina.Usuario.CPF,
                Nome = usuarioVacina.Usuario.Nome,
                DataNascimento = usuarioVacina.Usuario.DataNascimento,
                Email = usuarioVacina.Usuario.Email,
                Genero = usuarioVacina.Usuario.Genero,
                Passaporte = usuarioVacina.Usuario.Passaporte,
                Vacina = new ListarUsuarioComVacinaNegocioResponseVacina
                {
                    VacinaId = usuarioVacina.Vacina.VacinaId,
                    Nome = usuarioVacina.Vacina.Nome,
                    TipoVacina = usuarioVacina.Vacina.TipoVacina,
                    DosesNecessarias = usuarioVacina.Vacina.DosesNecessarias,
                    DosesAplicadoas = usuarioVacina.UsuarioDosesVacina.Count(x => x.UsuarioVacinaId == x.UsuarioDoseVacinaId && x.DataVacinacao != null),
                    ComVacinaValida = !usuarioVacina.UsuarioDosesVacina.Any(x => x.DataPrevisaoDose <= DateTime.Now && x.DataVacinacao == null),
                    Doses = usuarioVacina.UsuarioDosesVacina.Select(x => new ListarUsuarioComVacinaNegocioResponseDoseVacina
                    {
                        DataPrevisaoDose = x.DataPrevisaoDose,
                        DataVacinacao = x.DataVacinacao
                    }).ToList()
                }
            };

            return usuarioComVacinas;
        }

        public async Task<ListarUsuarioComVacinaNegocioResponse> Vacinar(VacinarUsuarioNegocioRequest request)
        {
            Usuario usuario = await _usuarioRepositorio.Obter(request.UsuarioId, true, true);
            if (usuario == null)
            {
                _notificacoes.AdicionarMensagem("Usuario não encontrado");
                return null;
            }


            Vacina vacina = await _vacinaRepositorio.Obter(request.VacinaId);
            if(vacina == null)
            {
                _notificacoes.AdicionarMensagem("Vacina não encontrada");
                return null;
            }

            UsuarioVacina usuarioVacina = await _usuarioVacinaRepositorio.Obter(request.UsuarioId, request.VacinaId, true, true, true);
            
            // Primeira vacinação
            if(usuarioVacina == null)
            {
                usuarioVacina = new UsuarioVacina(Guid.NewGuid(), request.UsuarioId, request.VacinaId);
                List<UsuarioDoseVacina> doses = new List<UsuarioDoseVacina>();

                doses.Add(new UsuarioDoseVacina(Guid.NewGuid(), usuarioVacina.UsuarioVacinaId, DateTime.Now.Date, DateTime.Now.Date));

                if(request.Previsoes.Count != vacina.DosesNecessarias-1)
                {
                    _notificacoes.AdicionarMensagem($"A vacina {vacina.Nome} requer a data de vacinação para {vacina.DosesNecessarias - 1} adicionais");
                    return null;
                }

                foreach (var previsao in request.Previsoes)
                    doses.Add(new UsuarioDoseVacina(Guid.NewGuid(), usuarioVacina.UsuarioVacinaId, null, previsao));

                await _usuarioVacinaRepositorio.Adicionar(usuarioVacina);
                await _usuarioDoseVacinaRepositorio.Adicionar(doses);


                ListarUsuarioComVacinaNegocioResponse usuarioComVacinas = new ListarUsuarioComVacinaNegocioResponse
                {
                    UsuarioId = usuario.UsuarioId,
                    CPF = usuario.CPF,
                    Nome = usuario.Nome,
                    DataNascimento = usuario.DataNascimento,
                    Email = usuario.Email,
                    Genero = usuario.Genero,
                    Passaporte = usuario.Passaporte,
                    Vacina = new ListarUsuarioComVacinaNegocioResponseVacina
                    {
                        VacinaId = vacina.VacinaId,
                        Nome = vacina.Nome,
                        TipoVacina = vacina.TipoVacina,
                        DosesNecessarias = vacina.DosesNecessarias,
                        DosesAplicadoas = doses.Count(x => x.UsuarioVacinaId == x.UsuarioVacinaId && x.DataVacinacao != null),
                        ComVacinaValida = true,
                        Doses = doses.Select(x => new ListarUsuarioComVacinaNegocioResponseDoseVacina
                        {
                            DataPrevisaoDose = x.DataPrevisaoDose,
                            DataVacinacao = x.DataVacinacao
                        }).ToList()
                    }
                };


                return usuarioComVacinas;

            }
            // Vacina doses posteriores
            else
            {
                UsuarioDoseVacina dose = usuarioVacina.UsuarioDosesVacina.Where(x => x.DataVacinacao == null)
                                                                         .OrderBy(x => x.DataPrevisaoDose)
                                                                         .FirstOrDefault();
                if (dose == null)
                {
                    _notificacoes.AdicionarMensagem("Usuário já tomou a ultima dose");
                    return null;
                }

                dose.Vacinar();
                _usuarioDoseVacinaRepositorio.Atualizar(dose);


                ListarUsuarioComVacinaNegocioResponse usuarioComVacinas = new ListarUsuarioComVacinaNegocioResponse
                {
                    UsuarioId = usuarioVacina.Usuario.UsuarioId,
                    CPF = usuarioVacina.Usuario.CPF,
                    Nome = usuarioVacina.Usuario.Nome,
                    DataNascimento = usuarioVacina.Usuario.DataNascimento,
                    Email = usuarioVacina.Usuario.Email,
                    Genero = usuarioVacina.Usuario.Genero,
                    Passaporte = usuarioVacina.Usuario.Passaporte,
                    Vacina = new ListarUsuarioComVacinaNegocioResponseVacina
                    {
                        VacinaId = usuarioVacina.Vacina.VacinaId,
                        Nome = usuarioVacina.Vacina.Nome,
                        TipoVacina = usuarioVacina.Vacina.TipoVacina,
                        DosesNecessarias = usuarioVacina.Vacina.DosesNecessarias,
                        DosesAplicadoas = usuarioVacina.UsuarioDosesVacina.Count(x => x.UsuarioVacinaId == x.UsuarioDoseVacinaId && x.DataVacinacao != null),
                        ComVacinaValida = !usuarioVacina.UsuarioDosesVacina.Any(x => x.DataPrevisaoDose <= DateTime.Now && x.DataVacinacao == null),
                        Doses = usuarioVacina.UsuarioDosesVacina.Select(x => new ListarUsuarioComVacinaNegocioResponseDoseVacina
                        {
                            DataPrevisaoDose = x.DataPrevisaoDose,
                            DataVacinacao = x.UsuarioDoseVacinaId == dose.UsuarioDoseVacinaId ? dose.DataVacinacao : x.DataVacinacao
                        }).ToList()
                    }
                };

                return usuarioComVacinas;

            }
        }

        public async Task<List<Usuario>> Listar()
        {
            List<Usuario> usuarios = await _usuarioRepositorio.Listar();
            return usuarios;
        }
    }
}
