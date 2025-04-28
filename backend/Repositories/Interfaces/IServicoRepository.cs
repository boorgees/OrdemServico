namespace OrdemServicoAPI.Repositories.Interfaces;

public interface IServicoRepository
{
    
    Task<IEnumerable<Servico>> GetAllServicosAsync();
    Task<Servico?> GetServicoByIdAsync(int id);
    Task AddServicoAsync(Servico servico);
    Task UpdateServicoAsync(Servico servico);
    Task DeleteServicoAsync(int id);
}