using OrdemServicoAPI.Repositories.Interfaces;
using OrdemServicoAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace OrdemServicoAPI.Repositories.Implementations;

public class ServicoRepository : IServicoRepository
{
    private readonly ApplicationDbContext _context;

    public ServicoRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<Servico>> GetAllServicosAsync()
    {
        return await _context.Servicos.ToListAsync();
    }

    public async Task<Servico?> GetServicoByIdAsync(int id)
    {
        return await _context.Servicos.FirstOrDefaultAsync(index => index.Id == id);
    }

    public async Task AddServicoAsync(Servico servico)
    {
        await _context.Servicos.AddAsync(servico);
        await _context.SaveChangesAsync();
        
    }
    
    public async Task UpdateServicoAsync(Servico servico)
    {
        _context.Servicos.Update(servico);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteServicoAsync(int id)
    {
        var servicoPraDeletar = await _context.Servicos.FindAsync(id);
        if (servicoPraDeletar != null)
        {
            _context.Servicos.Remove(servicoPraDeletar);
            await _context.SaveChangesAsync();
        }
    }
}