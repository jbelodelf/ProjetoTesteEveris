using JBD.ProjetoTesteEveris.Domain.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace JBD.ProjetoTesteEveris.Data.Contexts
{
    public class DataBaseContext : DbContext
    {
        private IConfiguration _configuration;
        public DataBaseContext(DbContextOptions<DataBaseContext> options, IConfiguration Configuration)
            : base(options)
        {
            _configuration = Configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(StringConectionConfig());
            }
        }

        public DbSet<ContaEntity> Conta { get; set; }
        public DbSet<ContaTransacaoEntity> ContaTransacao { get; set; }
        public DbSet<ContaMovimentoHistoricoEntity> ContaMovimentoHistorico { get; set; }

        private string StringConectionConfig()
        {
            return _configuration.GetConnectionString("DefaultConnection");
        }
    }
}
