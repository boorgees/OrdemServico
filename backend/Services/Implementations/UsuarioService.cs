using OrdemServicoAPI.Models;
using OrdemServicoAPI.Repositories;
using OrdemServicoAPI.Services.Interfaces;



namespace OrdemServicoAPI.Services
{
    public class UsuarioService : IUsuarioService
    {

        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<IEnumerable<Usuario>> GetAllUsuariosAsync()
        {
            return await _usuarioRepository.GetAllUsuariosAsync();
        }

        public async Task<Usuario> GetUsuarioByIdAsync(int id)
        {
            var usuario = await _usuarioRepository.GetUsuarioByIdAsync(id);
            if (usuario == null)
            {
                throw new Exception("Usuário não encontrado!");
            }
            return usuario;

        }

        public async Task<Usuario> GetByEmailAsync(string email)
        {
            var usuario = await _usuarioRepository.GetByEmailAsync(email);
            if (usuario == null)
            {
                throw new Exception("Usuário não encontrado!");
            }
            return usuario;
        }

        public async Task<Usuario> AddUsuarioAsync(Usuario usuario)
        {
            var existingUsuario = await _usuarioRepository.GetByEmailAsync(usuario.Email);
            if (existingUsuario != null)
            {
                throw new Exception("E-mail já existe!");
            }
            await _usuarioRepository.AddUsuarioAsync(usuario);
            return usuario;

        }

        public async Task<Usuario> UpdateAsync(Usuario usuario)
        {
            var existingUsuario = await _usuarioRepository.GetUsuarioByIdAsync(usuario.Id);
            if (existingUsuario == null)
            {
                throw new Exception("Usuário não encontrado!");
            }
            if (existingUsuario.Email != usuario.Email)
            {
                var emailExists = await _usuarioRepository.GetByEmailAsync(usuario.Email);
                if (emailExists != null)
                {
                    throw new Exception("E-mail já existe!");
                }
            }
            await _usuarioRepository.UpdateUsuarioAsync(usuario);
            return usuario;

        }

        public async Task DeleteAsync(int id)
        {
            var usuario = await _usuarioRepository.GetUsuarioByIdAsync(id);
            if (usuario == null)
            {
                throw new Exception("Usuário não encontrado!");
            }
            await _usuarioRepository.DeleteUsuarioAsync(id);
        }
    }
}