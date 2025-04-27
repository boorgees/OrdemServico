using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OrdemServicoAPI.Models;

[Keyless]
public class OrdemServicoServico
{
    public int OrdemServicoId { get; set; }
    public required OrdemServico OrdemServico { get; set; }
    public int ServicoId { get; set; }
    public required Servico Servico { get; set; }
}