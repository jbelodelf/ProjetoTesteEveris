using System;
using System.Collections.Generic;

namespace JBD.ProjetoTesteEveris.Domain.DTOS
{
    public class ContaDTO
    {
        public int CdConta { get; set; }
        public string ContaAgencia { get; set; }
        public string ContaNumero { get; set; }
        public int ContaTipo { get; set; }
        public int ContaStatus { get; set; }
        public decimal Saldo { get; set; }
        public DateTime DataAbertura { get; set; }

        public List<ContaMovimentoHistoricoDTO> ContaMovimentoHistorico { get; set; }
    }
}
