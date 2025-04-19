

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OrdemServicoAPI.Models
{
    public class Usuario
    {
        [Key, Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "O nome é obrigatório")]
        [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres")]
        public required string Nome { get; set; }
        [Required(ErrorMessage = "O e-mail é obrigatório"), EmailAddress(ErrorMessage = "O e-mail deve ser válido") ]
        [StringLength(100, ErrorMessage = "O e-mail deve ter no máximo 100 caracteres")]
        public required string Email { get; set; }
        [Required, MinLength(6, ErrorMessage = "A senha deve ter no mínimo 6 caracteres")]
        public required string Senha { get; set; }
        [Required, DisplayName("Data de Criação"), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataCriacao { get; set; } = DateTime.Now;
    }
    public enum TipoUsuarioEnum
    {
        [Description("Administrador")]
        Administrador = 0,
        [Description("Usuário Comum")]
        UsuarioComum = 1
    }
}