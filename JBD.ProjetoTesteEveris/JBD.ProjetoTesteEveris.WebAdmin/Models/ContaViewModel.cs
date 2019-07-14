using JBD.ProjetoTesteEveris.Domain.Enuns;
using System;
using System.Collections.Generic;

namespace JBD.ProjetoTesteEveris.WebAdmin.Models
{
    public class ContaViewModel
    {
        public int CdConta { get; set; }
        public string ContaAgencia { get; set; }
        public string ContaNumero { get; set; }
        public TipoContaEnum ContaTipo { get; set; }
        public StatusEnum ContaStatus { get; set; }
        public decimal Saldo { get; set; }

        public List<ContaMovimentoHistoricoViewModel> ContaMovimentoHistorico { get; set; }
    }
}
