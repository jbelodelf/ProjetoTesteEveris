using JBD.ProjetoTesteEveris.Domain.Enuns;
using System;

namespace JBD.ProjetoTesteEveris.Domain.DTOS
{
    public class ContaTransacaoDTO
    {
        public int CdTransacao { get; set; }
        public string AgContaOrigem { get; set; }
        public string NumContaOrigem { get; set; }
        public string AgContaDestino { get; set; }
        public string NumContaDestino { get; set; }
        public int TipoOperacao { get; set; }
        public decimal ValorOperacao { get; set; }
        public DateTime DataOperacao { get; set; }
    }
}
