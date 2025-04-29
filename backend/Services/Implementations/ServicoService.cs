using OrdemServicoAPI.Repositories.Interfaces;

namespace OrdemServicoAPI.Services.Implementations
{
    public class ServicoService : IServicosService
    {
        private readonly IServicoRepository _servicosRepository;

        public ServicoService(IServicoRepository servicosRepository)
        {
            _servicosRepository = servicosRepository;
        }

        public async Task<Servico> AddServicoAsync(Servico servico)
        {
            ValidarServico(servico);
            await _servicosRepository.AddServicoAsync(servico);
            return servico;
        }

        public async Task DeleteServicoAsync(int id)
        {
            var servicoDeletado = await _servicosRepository.GetServicoByIdAsync(id);
            if (servicoDeletado == null)
            {
                throw new KeyNotFoundException("Serviço não encontrado!");
            }
            if (servicoDeletado.OrdensServicos != null && servicoDeletado.OrdensServicos.Any())
            {
                throw new InvalidOperationException("Serviço não pode ser deletado, pois está vinculado a uma ordem de serviço!");
            }
            await _servicosRepository.DeleteServicoAsync(id);
        }

        public async Task<IEnumerable<Servico>> GetAllServicosAsync()
        {
            var servicos = await _servicosRepository.GetAllServicosAsync();
            return servicos ?? Enumerable.Empty<Servico>();
        }

        public async Task<Servico?> GetServicoByIdAsync(int id)
        {
            var servico = await _servicosRepository.GetServicoByIdAsync(id);
            if (servico == null)
            {
                throw new KeyNotFoundException("Serviço não encontrado!");
            }
            return servico;
        }

        public async Task<Servico?> GetServicoByNameAsync(string nome)
        {
            var servico = await _servicosRepository.GetServicoByNameAsync(nome);
            if (servico == null)
            {
                throw new KeyNotFoundException("Serviço não encontrado!");
            }
            return servico;
        }

        public async Task UpdateServicoAsync(Servico servico)
        {
            ValidarServico(servico);

            var servicoAtualizado = await _servicosRepository.GetServicoByIdAsync(servico.Id);
            if (servicoAtualizado == null)
            {
                throw new KeyNotFoundException("Serviço não encontrado!");
            }

            if (servicoAtualizado.OrdensServicos != null && servicoAtualizado.OrdensServicos.Any())
            {
                throw new InvalidOperationException("Serviço não pode ser atualizado, pois está vinculado a uma ordem de serviço!");
            }

            servicoAtualizado.Nome = servico.Nome;
            servicoAtualizado.Descricao = servico.Descricao;
            servicoAtualizado.Valor = servico.Valor;

            await _servicosRepository.UpdateServicoAsync(servicoAtualizado);
        }

        // serve para validar os dados do serviço antes de adicionar ou atualizar
        private void ValidarServico(Servico servico)
        {
            if (string.IsNullOrWhiteSpace(servico.Nome))
            {
                throw new ArgumentException("O campo Nome é obrigatório e não pode estar vazio!");
            }

            if (string.IsNullOrWhiteSpace(servico.Descricao))
            {
                throw new ArgumentException("O campo Descrição é obrigatório e não pode estar vazio!");
            }

            if (servico.Valor <= 0)
            {
                throw new ArgumentException("O campo Valor deve ser maior que zero!");
            }
        }
    }
}