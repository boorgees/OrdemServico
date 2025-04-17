using Microsoft.EntityFrameworkCore;
using OrdemServicoAPI.Models;

namespace OrdemServicoAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<OrdemServico> OrdemServico { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Servico> Servico { get; set; }
    }

}
