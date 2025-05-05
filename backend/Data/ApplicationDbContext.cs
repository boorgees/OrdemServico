using Microsoft.EntityFrameworkCore;
using OrdemServicoAPI.Models;

namespace OrdemServicoAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Servico> Servicos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<OrdemServico> OrdensServico { get; set; }
        public DbSet<OrdemServicoServico> OrdemServicoServicos { get; set; }

        // public DbSet<Anexo> Anexos { get; set; }
        // public DbSet<HistoricoAlteracao> HistoricosAlteracao { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<OrdemServicoServico>()
                .HasKey(oss => new { oss.OrdemServicoId, oss.ServicoId });

            modelBuilder.Entity<OrdemServicoServico>()
                .HasOne(oss => oss.OrdemServico)
                .WithMany(os => os.Servicos)
                .HasForeignKey(oss => oss.OrdemServicoId);

            modelBuilder.Entity<OrdemServicoServico>()
                .HasOne(oss => oss.Servico)
                .WithMany(s => s.OrdensServico)
                .HasForeignKey(oss => oss.ServicoId);
        }
    }
}