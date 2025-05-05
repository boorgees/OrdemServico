using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace OrdemServicoAPI.Models;

[PrimaryKey(nameof(OrdemServicoId), nameof(ServicoId))]
public class OrdemServicoServico
{
    public int OrdemServicoId { get; set; }
    public int ServicoId { get; set; }
    
    [JsonIgnore]
    public OrdemServico? OrdemServico { get; set; }
    public Servico? Servico { get; set; }
}