using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using OrdemServicoAPI.Models;

namespace OrdemServicoAPI
{
    public class Servico
    {
        [Key, Required] public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório"),
         StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres")]

        public required string Nome { get; set; }

        [Required(ErrorMessage = "A descrição é obrigatória")]
        [StringLength(500, ErrorMessage = "A descrição deve ter no máximo 500 caracteres")]
        [DisplayName("Descrição")]

        public required string Descricao { get; set; }

        [Required, DataType(DataType.Date), DisplayName("Data de Criação"),
         DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]

        public DateTime DataCriacao { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "O valor é obrigatório"), DataType(DataType.Currency),
         DisplayFormat(DataFormatString = "{0:C}")]
        [DisplayName("Valor")]
        public decimal Valor { get; set; }

        public required ICollection<OrdemServicoServico> OrdensServico { get; set; }
    }
}