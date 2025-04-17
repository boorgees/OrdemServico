using Microsoft.EntityFrameworkCore;
using OrdemServicoAPI.Models;

namespace OrdemServicoAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Servico> Servicos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<OrdemServico> OrdensServico { get; set; }
        // public DbSet<Anexo> Anexos { get; set; }
        // public DbSet<HistoricoAlteracao> HistoricosAlteracao { get; set; }
    }
}
