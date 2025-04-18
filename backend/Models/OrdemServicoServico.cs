using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrdemServicoAPI.Models;

public class OrdemServicoServico
{
    public int OrdemServicoId { get; set; }
    public OrdemServico OrdemServico { get; set; }
    public int ServicoId { get; set; }
    public Servico Servico { get; set; }
}