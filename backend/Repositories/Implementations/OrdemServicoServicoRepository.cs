using OrdemServicoAPI.Models;
using OrdemServicoAPI.Repositories.Interfaces;
using OrdemServicoAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace OrdemServicoAPI.Repositories.Implementations;

public class OrdemServicoServicoRepository : IOrdemServicoServicoRepository
{
    private readonly ApplicationDbContext _context;

    public OrdemServicoServicoRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<OrdemServicoServico>> GetAllAsync()
    {
        return await _context.OrdemServicoServicos.AsNoTracking()
            .Include(oss => oss.OrdemServico)
            .Include(oss => oss.Servico)
            .ToListAsync();
    }


    public async Task<OrdemServicoServico?> GetByIdAsync(int ordemServicoId, int servicoId)
    {
        return await _context.OrdemServicoServicos
            .Include(oss => oss.OrdemServico)
            .Include(oss => oss.Servico)
            .FirstOrDefaultAsync(oss =>
                oss.OrdemServicoId == ordemServicoId &&
                oss.ServicoId == servicoId);
    }


    public async Task<IEnumerable<OrdemServicoServico>> GetByOrdemServicoIdAsync(int ordemServicoId)
    {
        return await _context.OrdemServicoServicos
            .Where(oss => oss.OrdemServicoId == ordemServicoId)
            .Include(oss => oss.OrdemServico)
            .Include(oss => oss.Servico)
            .ToListAsync();
    }

    public async Task<IEnumerable<OrdemServicoServico>> GetByServicoIdAsync(int servicoId)
    {
        return await _context.OrdemServicoServicos
            .Where(oss => oss.ServicoId == servicoId)
            .Include(oss => oss.OrdemServico)
            .Include(oss => oss.Servico)
            .ToListAsync();
    }

    public async Task<OrdemServicoServico> CreateAsync(OrdemServicoServico ordemServicoServico)
    {
        _context.OrdemServicoServicos.Add(ordemServicoServico);
        await _context.SaveChangesAsync();
        return ordemServicoServico;
    }

    public async Task<bool> UpdateAsync(OrdemServicoServico ordemServicoServico)
    {
        var existingEntity = await _context.OrdemServicoServicos
            .FirstOrDefaultAsync(oss => oss.OrdemServicoId == ordemServicoServico.OrdemServicoId
                                        && oss.ServicoId == ordemServicoServico.ServicoId);

        if (existingEntity == null)
            return false;

        _context.Entry(existingEntity).CurrentValues.SetValues(ordemServicoServico);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int ordemServicoId, int servicoId)
    {
        var entity = await _context.OrdemServicoServicos
            .FirstOrDefaultAsync(oss => oss.OrdemServicoId == ordemServicoId && oss.ServicoId == servicoId);

        if (entity == null)
            return false;

        _context.OrdemServicoServicos.Remove(entity);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<OrdemServicoServico> AddAsync(OrdemServicoServico ordemServicoServico)
    {
        await _context.OrdemServicoServicos.AddAsync(ordemServicoServico);
        await _context.SaveChangesAsync();
        return ordemServicoServico;
    }
}