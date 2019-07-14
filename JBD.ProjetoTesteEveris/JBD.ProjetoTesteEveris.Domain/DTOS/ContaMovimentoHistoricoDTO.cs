using JBD.ProjetoTesteEveris.Domain.Enuns;
using System;

namespace JBD.ProjetoTesteEveris.Domain.DTOS
{
    public class ContaMovimentoHistoricoDTO
    {
        public int CdHistorico { get; set; }
        public int CdConta { get; set; }
        public string AgConta { get; set; }
        public string NumConta { get; set; }
        public int TipoOperacao { get; set; }
        public decimal SaldoAnterior { get; set; }
        public decimal ValorOperacao { get; set; }
        public decimal SaldoAtual { get; set; }
        public DateTime DataOperacao { get; set; }
    }
}
