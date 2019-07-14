using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JBD.ProjetoTesteEveris.Domain.Entitys
{
    [Table("tbConta", Schema = "dbo")]
    public class ContaEntity
    {
        public ContaEntity()
        {
            ContaMovimentoHistorico = new List<ContaMovimentoHistoricoEntity>();
        }

        [Key]
        public int CdConta { get; set; }
        public string ContaAgencia { get; set; }
        public string ContaNumero { get; set; }
        public int ContaTipo { get; set; }
        public int ContaStatus { get; set; }
        public decimal Saldo { get; set; }
        public DateTime DataAbertura { get; set; }

        public List<ContaMovimentoHistoricoEntity> ContaMovimentoHistorico { get; set; }
    }
}
