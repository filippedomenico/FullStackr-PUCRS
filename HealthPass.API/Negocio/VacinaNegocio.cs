using HealthPass.API.Entidades;
using HealthPass.API.Interfaces.Base;
using HealthPass.API.Interfaces.Persistencia.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthPass.API.Negocio
{
    public class VacinaNegocio : IVacinaNegocio
    {
        private readonly IVacinaRepositorio _vacinaRepositorio;
        private readonly INotificacoes _notificacoes;

        public VacinaNegocio(IVacinaRepositorio vacinaRepositorio)
        {
            _vacinaRepositorio = vacinaRepositorio;
        }

        public async Task<Vacina> Obter(Guid vacinaId)
        {
            Vacina vacina = await _vacinaRepositorio.Obter(vacinaId);

            if(vacina == null)
            {
                _notificacoes.AdicionarMensagem("Vacina não encontrada");
                return null;
            }

            return vacina;
        }

        public async Task<List<Vacina>> Listar()
        {
            return await _vacinaRepositorio.Listar();
        }

        public async Task<Vacina> Adicionar(Vacina vacina)
        {
            if(vacina.Nome.Length > 100)
            {
                _notificacoes.AdicionarMensagem("Nome da vacina não pode ter mais de 100 caracteres");
                return null;
            }

            await _vacinaRepositorio.Adicionar(vacina);

            return vacina;
        }

        public async Task<Vacina> Alterar(Vacina vacina)
        {
            if (vacina.Nome.Length > 100)
            {
                _notificacoes.AdicionarMensagem("Nome da vacina não pode ter mais de 100 caracteres");
                return null;
            }

            Vacina vacinaParaAlterar = await _vacinaRepositorio.Obter(vacina.VacinaId);

            if(vacinaParaAlterar == null)
            {
                _notificacoes.AdicionarMensagem("Vacina não encontrada");
                return null;
            }


            vacinaParaAlterar.SetarNome(vacina.Nome)
                             .SetarDisponibilidade(vacina.Disponivel);

            _vacinaRepositorio.Atualizar(vacina);

            return vacina;
        }
    }
}
