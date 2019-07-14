using JBD.ProjetoTesteEveris.Domain.Enuns;
using System;
using System.Collections.Generic;

namespace JBD.ProjetoTesteEveris.WebAdmin.Models
{
    public class ContaMovimentoHistoricoViewModel
    {
        public int CdHistorico { get; set; }
        public int CdConta { get; set; }
        public string AgConta { get; set; }
        public string NumConta { get; set; }
        public TipoOperacaoEnum TipoOperacao { get; set; }
        public decimal SaldoAnterior { get; set; }
        public decimal ValorOperacao { get; set; }
        public decimal SaldoAtual { get; set; }
        public DateTime DataOperacao { get; set; }
    }
}
