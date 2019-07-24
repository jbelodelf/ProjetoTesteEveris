using JBD.ProjetoTesteEveris.Domain.DTOS;
using JBD.ProjetoTesteEveris.Domain.Entitys;
using JBD.ProjetoTesteEveris.Domain.Interfaces.Repository;
using JBD.ProjetoTesteEveris.Domain.Interfaces.Service;
using System;

namespace JBD.ProjetoTesteEveris.Domain.Services.Validar
{
    public class ValidarTransacao : IValidarTransacaoService
    {
        private readonly IContaRepository _conta;
        public ValidarTransacao(IContaRepository conta)
        {
            _conta = conta;
        }

        public bool TransacaoValida(ContaTransacaoDTO contaTransacaoDTO)
        {
            var contaTransacaoEntity = new ContaTransacaoEntity();
            var contaTransacaoEntityValida = contaTransacaoEntity.ValidaContaTransacaoEntity(
                    contaTransacaoDTO.CdTransacao,
                    contaTransacaoDTO.AgContaOrigem,
                    contaTransacaoDTO.NumContaOrigem,
                    contaTransacaoDTO.AgContaDestino,
                    contaTransacaoDTO.NumContaDestino,
                    contaTransacaoDTO.TipoOperacao,
                    contaTransacaoDTO.ValorOperacao,
                    contaTransacaoDTO.DataOperacao
                );
            return true;
        }

        public bool ValidaContasOrigemDestino(ContaTransacaoDTO contaTransacaoDTO)
        {
            var listaDeContas = _conta.ListarContas(contaTransacaoDTO.AgContaOrigem, contaTransacaoDTO.NumContaOrigem, contaTransacaoDTO.AgContaDestino, contaTransacaoDTO.NumContaDestino);

            if (listaDeContas.Count == 0)
                throw new ArgumentException("Nenhum conta foi localizada");

            var ContaOrigem = listaDeContas.Find(c => c.ContaAgencia == contaTransacaoDTO.AgContaOrigem && c.ContaNumero == contaTransacaoDTO.NumContaOrigem);
            if (ContaOrigem == null)
                throw new ArgumentException("Conta origem não localizada");

            if (ContaOrigem.Saldo < contaTransacaoDTO.ValorOperacao)
                throw new ArgumentException("Saldo insuficiente");

            var ContaDestino = listaDeContas.Find(c => c.ContaAgencia == contaTransacaoDTO.AgContaDestino && c.ContaNumero == contaTransacaoDTO.NumContaDestino);
            if (ContaDestino == null)
                throw new ArgumentException("Conta destino não localizada");

            return true;
        }
    }
}
