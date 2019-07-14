using JBD.ProjetoTesteEveris.Domain.Enuns;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JBD.ProjetoTesteEveris.Domain.Entitys
{
    [Table("tbContaMovimentoHistorico", Schema = "dbo")]
    public class ContaMovimentoHistoricoEntity
    {
        [Key]
        public int CdHistorico { get; set; }
        [ForeignKey("CdConta")]
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
