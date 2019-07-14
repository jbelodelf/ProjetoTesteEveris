using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JBD.ProjetoTesteEveris.Domain.Entitys
{
    [Table("tbContaTransacao", Schema = "dbo")]
    public class ContaTransacaoEntity
    {
        [Key]
        public int CdTransacao { get; set; }
        public string AgContaOrigem { get; set; }
        public string NumContaOrigem { get; set; }
        public string AgContaDestino { get; set; }
        public string NumContaDestino { get; set; }
        public int TipoOperacao { get; set; }
        public decimal ValorOperacao { get; set; }
        public DateTime DataOperacao { get; set; }

        public ContaTransacaoEntity ValidaContaTransacaoEntity(int CdTransacao, string AgContaOrigem, string NumContaOrigem, string AgContaDestino, string NumContaDestino, int TipoOperacao, decimal ValorOperacao, DateTime DataOperacao)
        {
            if (String.IsNullOrEmpty(AgContaOrigem))
                throw new ArgumentException("Agência origem inválida");
            if (String.IsNullOrEmpty(NumContaOrigem))
                throw new ArgumentException("Conta origem inválida");
            if (String.IsNullOrEmpty(AgContaDestino))
                throw new ArgumentException("Agência destino inválida");
            if (String.IsNullOrEmpty(NumContaDestino))
                throw new ArgumentException("Conta destino inválida");
            if (ValorOperacao < 1)
                throw new ArgumentException("Valor da transação inválida");
            if (DataOperacao == Convert.ToDateTime("01/01/0001 00:00:00"))
                throw new ArgumentException("Data da transação inválida");

            this.CdTransacao = CdTransacao;
            this.AgContaOrigem = AgContaOrigem;
            this.NumContaOrigem = NumContaOrigem;
            this.AgContaDestino = AgContaDestino;
            this.NumContaDestino = NumContaDestino;
            this.TipoOperacao = TipoOperacao;
            this.ValorOperacao = ValorOperacao;
            this.DataOperacao = DataOperacao;

            return this;
        }
    }

}
