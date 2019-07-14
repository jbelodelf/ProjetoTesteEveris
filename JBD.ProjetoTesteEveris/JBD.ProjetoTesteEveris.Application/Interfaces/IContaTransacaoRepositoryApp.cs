using JBD.ProjetoTesteEveris.Domain.DTOS;
using System.Collections.Generic;

namespace JBD.ProjetoTesteEveris.Application.Interfaces
{
    public interface IContaTransacaoRepositoryApp
    {
        List<ContaTransacaoDTO> ListarContaTransacaos(string agOrigem, string numContaOrigem);
        ContaTransacaoDTO ObterContaTransacaoById(int Id);
        void Salvar(ContaTransacaoDTO contaTransacao);
        void Atualizar(ContaTransacaoDTO contaTransacao);
    }
}
