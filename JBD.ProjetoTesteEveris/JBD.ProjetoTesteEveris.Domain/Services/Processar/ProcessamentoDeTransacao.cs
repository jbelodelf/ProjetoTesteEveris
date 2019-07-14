using JBD.ProjetoTesteEveris.Domain.DTOS;
using JBD.ProjetoTesteEveris.Domain.Enuns;
using JBD.ProjetoTesteEveris.Domain.Interfaces.Repository;
using JBD.ProjetoTesteEveris.Domain.Interfaces.Service;
using System;

namespace JBD.ProjetoTesteEveris.Domain.Services.Processar
{
    public class ProcessamentoDeTransacao : IProcessamentoDeTransacaoService
    {
        private readonly IContaRepository _conta;
        private readonly IContaMovimentoHistoricoRepository _historico;
        public ProcessamentoDeTransacao(IContaRepository conta, IContaMovimentoHistoricoRepository historico)
        {
            _conta = conta;
            _historico = historico;
        }

        public bool ProcessarTransacao(ContaTransacaoDTO transacaoDTO)
        {
            var listaDeContas = _conta.ListarContas(transacaoDTO.AgContaOrigem, transacaoDTO.NumContaOrigem, transacaoDTO.AgContaDestino, transacaoDTO.NumContaDestino);

            var ContaOrigem = listaDeContas.Find(c => c.ContaAgencia == transacaoDTO.AgContaOrigem && c.ContaNumero == transacaoDTO.NumContaOrigem);
            var ContaDestino = listaDeContas.Find(c => c.ContaAgencia == transacaoDTO.AgContaDestino && c.ContaNumero == transacaoDTO.NumContaDestino);

            if (ContaOrigem == null || ContaDestino == null)
            {
                throw new ArgumentException("Ocorreu uma falha na transação");
            }

            ContaMovimentoHistoricoDTO movimentoHistoricoContaOrigemDTO = new ContaMovimentoHistoricoDTO()
            {
                CdConta = ContaOrigem.CdConta,
                AgConta = ContaOrigem.ContaAgencia,
                NumConta = ContaOrigem.ContaNumero,
                SaldoAnterior = ContaOrigem.Saldo,
                SaldoAtual = (ContaOrigem.Saldo - transacaoDTO.ValorOperacao),
                TipoOperacao = (int)TipoOperacaoEnum.Debito,
                ValorOperacao = transacaoDTO.ValorOperacao,
                DataOperacao = transacaoDTO.DataOperacao
            };

            ContaMovimentoHistoricoDTO movimentoHistoricoContaDestinoDTO = new ContaMovimentoHistoricoDTO()
            {
                CdConta = ContaDestino.CdConta,
                AgConta = ContaDestino.ContaAgencia,
                NumConta = ContaDestino.ContaNumero,
                SaldoAnterior = ContaDestino.Saldo,
                SaldoAtual = (ContaDestino.Saldo + transacaoDTO.ValorOperacao),
                TipoOperacao = (int)TipoOperacaoEnum.Credito,
                ValorOperacao = transacaoDTO.ValorOperacao,
                DataOperacao = transacaoDTO.DataOperacao
            };

            ContaOrigem.Saldo -= transacaoDTO.ValorOperacao;
            ContaDestino.Saldo += transacaoDTO.ValorOperacao;

            _conta.Atualizar(ContaOrigem);
            _conta.Atualizar(ContaDestino);

            _historico.Salvar(movimentoHistoricoContaOrigemDTO);
            _historico.Salvar(movimentoHistoricoContaDestinoDTO);

            return true;
        }
    }
}
