using OrdemServicoAPI.Models;

namespace OrdemServicoAPI.Repositories
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<Usuario>> GetAllUsuariosAsync();
        Task<Usuario?> GetUsuarioByIdAsync(int id);
        Task<Usuario?> GetUsuarioByEmailAsync(string email);
        Task AddUsuarioAsync(Usuario usuario);
        Task UpdateUsuarioAsync(Usuario usuario);
        Task DeleteUsuarioAsync(int id);
    }
}