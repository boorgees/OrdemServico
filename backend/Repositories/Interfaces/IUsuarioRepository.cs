using OrdemServicoAPI.Models;

namespace OrdemServicoAPI.Repositories
{
    public interface IUsuarioRepository
    {
        Task<Usuario?> GetUsuarioByIdAsync(int id);
        Task<Usuario?> GetByEmailAsync(string email);
        Task<IEnumerable<Usuario>> GetAllUsuariosAsync();
        Task AddUsuarioAsync(Usuario usuario);
        Task UpdateUsuarioAsync(Usuario usuario);
        Task DeleteUsuarioAsync(int id);
       
    }
}