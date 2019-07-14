using JBD.ProjetoTesteEveris.Domain.DTOS;
using System.Collections.Generic;

namespace JBD.ProjetoTesteEveris.Domain.Interfaces.Service
{
    public interface IContaTransacaoRepositoryService
    {
        List<ContaTransacaoDTO> ListarContaTransacaos(string agOrigem, string numContaOrigem);
        ContaTransacaoDTO ObterContaTransacaoById(int Id);
        void Salvar(ContaTransacaoDTO contaTransacao);
        void Atualizar(ContaTransacaoDTO contaTransacao);
    }
}
