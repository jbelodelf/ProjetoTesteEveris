using JBD.ProjetoTesteEveris.Domain.DTOS;
using JBD.ProjetoTesteEveris.Domain.Interfaces.Repository;
using JBD.ProjetoTesteEveris.Domain.Interfaces.Service;
using System.Collections.Generic;

namespace JBD.ProjetoTesteEveris.Domain.Services
{
    public class ContaMovimentoHistoricoRepositoryService : IContaMovimentoHistoricoRepositoryService
    {
        private readonly IContaMovimentoHistoricoRepository _repository = null;

        public ContaMovimentoHistoricoRepositoryService(IContaMovimentoHistoricoRepository repository)
        {
            _repository = repository;
        }

        public List<ContaMovimentoHistoricoDTO> ListarContaMovimentoHistoricos(int cdConta)
        {
            return _repository.ListarContaMovimentoHistoricos(cdConta);
        }

        public ContaMovimentoHistoricoDTO ObterContaMovimentoHistoricoById(int Id)
        {
            return _repository.ObterContaMovimentoHistoricoById(Id);
        }

        public void Salvar(ContaMovimentoHistoricoDTO contaMovimentoHistorico)
        {
            _repository.Salvar(contaMovimentoHistorico);
        }
    }
}
