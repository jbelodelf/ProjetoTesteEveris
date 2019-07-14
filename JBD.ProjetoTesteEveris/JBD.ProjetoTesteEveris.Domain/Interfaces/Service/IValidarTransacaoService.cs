using JBD.ProjetoTesteEveris.Domain.DTOS;

namespace JBD.ProjetoTesteEveris.Domain.Interfaces.Service
{
    public interface IValidarTransacaoService
    {
        bool TransacaoValida(ContaTransacaoDTO contaTransacaoDTO);
    }
}
