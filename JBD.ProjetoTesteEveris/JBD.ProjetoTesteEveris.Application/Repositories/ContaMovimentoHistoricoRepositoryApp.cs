using JBD.ProjetoTesteEveris.Application.Interfaces;
using JBD.ProjetoTesteEveris.Domain.DTOS;
using JBD.ProjetoTesteEveris.Domain.Interfaces.Service;
using System.Collections.Generic;

namespace JBD.ProjetoTesteEveris.Application.Repositories
{
    public class ContaMovimentoHistoricoRepositoryApp : IContaMovimentoHistoricoRepositoryApp
    {
        IContaMovimentoHistoricoRepositoryService _sevice = null;

        public ContaMovimentoHistoricoRepositoryApp(IContaMovimentoHistoricoRepositoryService sevice)
        {
            _sevice = sevice;
        }
        public List<ContaMovimentoHistoricoDTO> ListarContaMovimentoHistoricos(int cdConta)
        {
            return _sevice.ListarContaMovimentoHistoricos(cdConta);
        }

        public ContaMovimentoHistoricoDTO ObterContaMovimentoHistoricoById(int Id)
        {
            return _sevice.ObterContaMovimentoHistoricoById(Id);
        }

        public void Salvar(ContaMovimentoHistoricoDTO contaMovimentoHistorico)
        {
            _sevice.Salvar(contaMovimentoHistorico);
        }
    }
}
