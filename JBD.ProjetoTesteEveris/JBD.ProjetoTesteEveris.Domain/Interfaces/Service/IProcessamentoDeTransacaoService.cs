using JBD.ProjetoTesteEveris.Domain.DTOS;

namespace JBD.ProjetoTesteEveris.Domain.Interfaces.Service
{
    public interface IProcessamentoDeTransacaoService
    {
        bool ProcessarTransacao(ContaTransacaoDTO transacaoDTO);
    }
}
