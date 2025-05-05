using OrdemServicoAPI.Models;
using OrdemServicoAPI.Repositories.Interfaces;
using OrdemServicoAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace OrdemServicoAPI.Repositories
{
    public class OrdemServicoRepository : IOrdemServicoRepository
    {
        private readonly ApplicationDbContext _context;

        public OrdemServicoRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<OrdemServico>> GetAllAsync()
        {
            return await _context.OrdensServico
                .Include(o => o.Cliente)
                .Include(o => o.Usuario)
                .Include(o => o.Servicos)
                    .ThenInclude(os => os.Servico)
                .ToListAsync();
        }

        public Task<OrdemServico?> GetByIdAsync(int id)
        {
            return _context.OrdensServico
                .Include(o => o.Cliente)
                .Include(o => o.Usuario)
                .Include(o => o.Servicos)
                    .ThenInclude(os => os.Servico)
                .AsNoTracking()
                .FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task<OrdemServico> AddAsync(OrdemServico ordem)
        {
            await _context.OrdensServico.AddAsync(ordem);
            await _context.SaveChangesAsync();
            return ordem;
        }

        public async Task UpdateAsync(OrdemServico ordem)
        {
            var ordemExistente = await _context.OrdensServico.FindAsync(ordem.Id);

            if (ordemExistente != null)
            {
                _context.Entry(ordemExistente).CurrentValues.SetValues(ordem);

                await _context.SaveChangesAsync();
            }
        }


        public async Task DeleteAsync(int id)
        {
            var ordem = await _context.OrdensServico.FindAsync(id);
            if (ordem != null)
            {
                _context.OrdensServico.Remove(ordem);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<OrdemServico>> GetOrdensServicoByClienteAsync(int clienteId)
        {
            return await _context.OrdensServico
                .Include(o => o.Cliente)
                .Include(o => o.Servicos)
                    .ThenInclude(oss => oss.Servico)
                .Where(o => o.ClienteId == clienteId)
                .ToListAsync();
        }

        public async Task<IEnumerable<OrdemServico>> GetOrdensServicoByStatusAsync(StatusEnum status)
        {
            return await _context.OrdensServico
                .Include(o => o.Cliente)
                .Include(o => o.Servicos)
                    .ThenInclude(oss => oss.Servico)
                .Where(o => o.Status == status)
                .ToListAsync();
        }
    }
}