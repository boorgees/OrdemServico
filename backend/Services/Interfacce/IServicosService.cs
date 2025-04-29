namespace OrdemServicoAPI.Services
{
    public interface IServicosService
    {
        Task<IEnumerable<Servico>> GetAllServicosAsync();
        Task<Servico?> GetServicoByIdAsync(int id);
        Task<Servico?> GetServicoByNameAsync(string nome);
        Task<Servico> AddServicoAsync(Servico servico);
        Task UpdateServicoAsync(Servico servico);
        Task DeleteServicoAsync(int id);
    }
}