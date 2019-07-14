using JBD.ProjetoTesteEveris.Application.Interfaces;
using JBD.ProjetoTesteEveris.Domain.DTOS;
using JBD.ProjetoTesteEveris.Domain.Interfaces.Service;
using System.Collections.Generic;

namespace JBD.ProjetoTesteEveris.Application.Repositories
{
    public class ContaTransacaoRepositoryApp : IContaTransacaoRepositoryApp
    {
        IContaTransacaoRepositoryService _sevice = null;

        public ContaTransacaoRepositoryApp(IContaTransacaoRepositoryService sevice)
        {
            _sevice = sevice;
        }

        public List<ContaTransacaoDTO> ListarContaTransacaos(string agOrigem, string numContaOrigem)
        {
            return _sevice.ListarContaTransacaos(agOrigem, numContaOrigem);
        }

        public ContaTransacaoDTO ObterContaTransacaoById(int Id)
        {
            return _sevice.ObterContaTransacaoById(Id);
        }

        public void Salvar(ContaTransacaoDTO contaTransacao)
        {
            _sevice.Salvar(contaTransacao);
        }

        public void Atualizar(ContaTransacaoDTO contaTransacao)
        {
            _sevice.Atualizar(contaTransacao);
        }

    }
}
