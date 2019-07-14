using JBD.ProjetoTesteEveris.Domain.DTOS;
using JBD.ProjetoTesteEveris.Domain.Interfaces.Repository;
using JBD.ProjetoTesteEveris.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;

namespace JBD.ProjetoTesteEveris.Domain.Services
{
    public class ContaTransacaoRepositoryService : IContaTransacaoRepositoryService
    {
        private readonly IContaTransacaoRepository _repository = null;
        private readonly IContaRepository _contaService = null;
        private readonly IContaMovimentoHistoricoRepository _historicoService = null;
        private readonly IValidarTransacaoService _validarTransacaoService = null;
        private readonly IProcessamentoDeTransacaoService _processamentoDeTransacaoService = null;

        public ContaTransacaoRepositoryService(IContaTransacaoRepository repository
            , IContaRepository contaService
            , IContaMovimentoHistoricoRepository historicoService
            , IValidarTransacaoService validarTransacaoService
            , IProcessamentoDeTransacaoService processamentoDeTransacaoService)
        {
            _repository = repository;
            _contaService = contaService;
            _historicoService = historicoService;
            _validarTransacaoService = validarTransacaoService;
            _processamentoDeTransacaoService = processamentoDeTransacaoService;
        }

        public List<ContaTransacaoDTO> ListarContaTransacaos(string agOrigem, string numContaOrigem)
        {
            return _repository.ListarContaTransacaos(agOrigem, numContaOrigem);
        }

        public ContaTransacaoDTO ObterContaTransacaoById(int Id)
        {
            return _repository.ObterContaTransacaoById(Id);
        }

        public void Salvar(ContaTransacaoDTO contaTransacao)
        {
            try
            {
                bool processarTransacao_Ok = false;

                var transacaoValida = _validarTransacaoService.TransacaoValida(contaTransacao);

                if (transacaoValida)
                {
                    processarTransacao_Ok = _processamentoDeTransacaoService.ProcessarTransacao(contaTransacao);
                }

                if (processarTransacao_Ok)
                {
                    _repository.Salvar(contaTransacao);
                }
                else
                {
                    throw new ArgumentException("Ocorreu uma falha na transação");
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Ocorreu uma falha na transação");
            }
        }

        public void Atualizar(ContaTransacaoDTO contaTransacao)
        {
            _repository.Atualizar(contaTransacao);
        }
    }
}
