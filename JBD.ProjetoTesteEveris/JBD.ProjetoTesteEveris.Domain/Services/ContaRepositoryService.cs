using JBD.ProjetoTesteEveris.Domain.DTOS;
using JBD.ProjetoTesteEveris.Domain.Interfaces.Repository;
using JBD.ProjetoTesteEveris.Domain.Interfaces.Service;
using System.Collections.Generic;

namespace JBD.ProjetoTesteEveris.Domain.Services
{
    public class ContaRepositoryService : IContaRepositoryService
    {
        private readonly IContaRepository _repository = null;

        public ContaRepositoryService(IContaRepository repository)
        {
            _repository = repository;
        }

        public void Deletar(int Id)
        {
            _repository.Deletar(Id);
        }

        public List<ContaDTO> ListarContas(string agOrigem, string numContaOrigem, string agDestino, string numContaDestino)
        {

            return _repository.ListarContas(agOrigem, numContaOrigem, agDestino, numContaDestino);
        }

        public List<ContaDTO> ListarContas(string nome, string cnpjcpf)
        {
            return _repository.ListarContas(nome, cnpjcpf);
        }

        public ContaDTO ObterContaById(int Id)
        {
            return _repository.ObterContaById(Id);
        }

        public void Salvar(ContaDTO conta)
        {
            _repository.Salvar(conta);
        }

        public void Atualizar(ContaDTO conta)
        {
            _repository.Atualizar(conta);
        }

        public ContaDTO ObterConta(string agConta, string numConta)
        {
            return _repository.ObterConta(agConta, numConta);
        }
    }
}
