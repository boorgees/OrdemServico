using OrdemServicoAPI.Services.Interfaces;
using OrdemServicoAPI.Repositories.Interfaces;
using OrdemServicoAPI.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace OrdemServicoAPI.Services
{
    public class OrdemServicoService : IOrdemServicoService
    {
        private readonly IOrdemServicoRepository _ordemServicoRepository;
        public OrdemServicoService(IOrdemServicoRepository ordemServicoRepository)
        {
            _ordemServicoRepository = ordemServicoRepository;
        }

        public async Task<OrdemServico> AddOrdemServicoAsync(OrdemServico ordemServico)
        {
            var ordemServicoNova = await _ordemServicoRepository.AddAsync(ordemServico);
            if (ordemServicoNova == null)
            {
                throw new InvalidOperationException("Erro ao adicionar ordem de serviço! Verifique os dados e tente novamente.");
            }
            ValidarDatas(ordemServicoNova);

            return ordemServicoNova;
        }

        public async Task DeleteOrdemServicoAsync(int id)
        {
            var ordemServico = await _ordemServicoRepository.GetByIdAsync(id);
            if (ordemServico == null)
            {
                throw new KeyNotFoundException("Ordem de serviço não encontrada!");
            }
            if (ordemServico.Servicos != null && ordemServico.Servicos.Any())
            {
                throw new InvalidOperationException("Ordem de serviço não pode ser deletada, pois está vinculada a um serviço!");
            }
            await _ordemServicoRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<OrdemServico>> GetAllOrdensServicoAsync()
        {
            var ordensServico = await _ordemServicoRepository.GetAllAsync();
            if (ordensServico == null || !ordensServico.Any())
            {
                throw new KeyNotFoundException("Nenhuma ordem de serviço encontrada!");
            }

            return ordensServico;
        }

        public async Task<OrdemServico?> GetOrdemServicoByIdAsync(int id)
        {
            var ordemServico = await _ordemServicoRepository.GetByIdAsync(id);
            if (ordemServico == null)
            {
                throw new KeyNotFoundException("Ordem de serviço não encontrada!");
            }
            return ordemServico;
        }

        public Task UpdateOrdemServicoAsync(OrdemServico ordemServico)
        {
            var ordemServicoAtual = _ordemServicoRepository.GetByIdAsync(ordemServico.Id).Result;
            if (ordemServicoAtual == null)
            {
                throw new KeyNotFoundException("Ordem de serviço não encontrada!");
            }
            if (ordemServico.Servicos != null && ordemServico.Servicos.Any())
            {
                throw new InvalidOperationException("Ordem de serviço não pode ser atualizada, pois está vinculada a um serviço!");
            }
            if (ordemServico.DataConclusao.HasValue && ordemServico.DataConclusao < ordemServico.DataCriacao)
            {
                throw new ArgumentException("A data de conclusão não pode ser anterior à data de criação.");
            }
            ValidarDatas(ordemServico);
            return _ordemServicoRepository.UpdateAsync(ordemServico);
        }

        public void ValidarDatas(OrdemServico ordemServico)
        {
            if (ordemServico.DataConclusao.HasValue && ordemServico.DataConclusao < ordemServico.DataCriacao)
            {
                throw new ArgumentException("A data de conclusão não pode ser anterior à data de criação.");
            }
        }
    }
}