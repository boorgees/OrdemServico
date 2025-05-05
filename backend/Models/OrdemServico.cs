using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace OrdemServicoAPI.Models
{
    public class OrdemServico
    {
        [Key, Required]
        public int Id { get; set; }

        [ForeignKey("Cliente")]
        [Required(ErrorMessage = "O cliente é obrigatório")]
        [DisplayName("Cliente")]
        public int ClienteId { get; set; }

        [ForeignKey("Usuario")]
        [Required(ErrorMessage = "O usuário é obrigatório")]
        [DisplayName("Usuário")]
        public int UsuarioId { get; set; }

        [Required(ErrorMessage = "O título é obrigatório")]
        [StringLength(100, ErrorMessage = "O título deve ter no máximo 100 caracteres")]
        public string Titulo { get; set; } = string.Empty;

        [Required(ErrorMessage = "A descrição é obrigatória")]
        [StringLength(100, ErrorMessage = "A descrição deve ter no máximo 100 caracteres.")]
        public string Descricao { get; set; } = string.Empty;

        [Required(ErrorMessage = "A data de início é obrigatória")]
        [DataType(DataType.Date)]
        [DisplayName("Data de Início")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataCriacao { get; set; } = DateTime.UtcNow;

        [DataType(DataType.Date)]
        [DisplayName("Data de Conclusão")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? DataConclusao { get; set; }

        [Required(ErrorMessage = "O status é obrigatório")]
        public StatusEnum Status { get; set; }

        // Relações de navegação
        public Cliente? Cliente { get; set; }
        public Usuario? Usuario { get; set; }

        [DisplayName("Serviços")]
        [InverseProperty("OrdemServico")]
        public ICollection<OrdemServicoServico>? Servicos { get; set; }
    }


    public enum StatusEnum
    {
        [Description("Pendente")] Pendente = 0,
        [Description("Em Andamento")] EmAndamento = 1,
        [Description("Aguardando Aprovação")] AguardandoAprovacao = 2,
        [Description("Concluído")] Concluido = 3,
        [Description("Cancelado")] Cancelado = 4
    }
}