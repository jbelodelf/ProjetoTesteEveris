using JBD.ProjetoTesteEveris.Application.Interfaces;
using JBD.ProjetoTesteEveris.Domain.DTOS;
using JBD.ProjetoTesteEveris.Domain.Interfaces.Service;
using System.Collections.Generic;

namespace JBD.ProjetoTesteEveris.Application.Repositories
{
    public class ContaRepositoryApp : IContaRepositoryApp
    {
        IContaRepositoryService _sevice = null;

        public ContaRepositoryApp(IContaRepositoryService sevice)
        {
            _sevice = sevice;
        }

        public void Deletar(int Id)
        {
            _sevice.Deletar(Id);
        }

        public List<ContaDTO> ListarContas(string agOrigem, string numContaOrigem, string agDestino, string numContaDestino)
        {

            return _sevice.ListarContas(agOrigem, numContaOrigem, agDestino, numContaDestino);
        }

        public List<ContaDTO> ListarContas(string nome, string cnpjcpf)
        {
            return _sevice.ListarContas(nome, cnpjcpf);
        }

        public ContaDTO ObterContaById(int Id)
        {
            return _sevice.ObterContaById(Id);
        }

        public void Salvar(ContaDTO conta)
        {
            _sevice.Salvar(conta);
        }

        public void Atualizar(ContaDTO conta)
        {
            _sevice.Atualizar(conta);
        }

        public ContaDTO ObterConta(string agConta, string numConta)
        {
            return _sevice.ObterConta(agConta, numConta);
        }
    }
}
