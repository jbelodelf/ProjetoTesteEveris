using JBD.ProjetoTesteEveris.Domain.DTOS;
using System.Collections.Generic;

namespace JBD.ProjetoTesteEveris.Domain.Interfaces.Repository
{
    public interface IContaMovimentoHistoricoRepository
    {
        List<ContaMovimentoHistoricoDTO> ListarContaMovimentoHistoricos(int cdConta);
        ContaMovimentoHistoricoDTO ObterContaMovimentoHistoricoById(int Id);
        void Salvar(ContaMovimentoHistoricoDTO contaMovimentoHistorico);
    }
}
