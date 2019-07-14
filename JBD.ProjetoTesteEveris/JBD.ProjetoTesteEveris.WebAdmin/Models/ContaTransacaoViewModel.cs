using JBD.ProjetoTesteEveris.Domain.Enuns;
using System;
using System.Collections.Generic;

namespace JBD.ProjetoTesteEveris.WebAdmin.Models
{
    public class ContaTransacaoViewModel
    {
        public int CdTransacao { get; set; }
        public string AgContaOrigem { get; set; }
        public string NumContaOrigem { get; set; }
        public string AgContaDestino { get; set; }
        public string NumContaDestino { get; set; }
        public TipoOperacaoEnum TipoOperacao { get; set; }
        public decimal ValorOperacao { get; set; }
        public DateTime DataOperacao { get; set; }
    }
}
