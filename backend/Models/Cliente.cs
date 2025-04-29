using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace OrdemServicoAPI.Models
{
    public class Cliente
    {
        [Key, Required] public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório"),
         StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres")]
        [DisplayName("Nome")]
        public required string Nome { get; set; }

        [Required(ErrorMessage = "O CPF é obrigatório")]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "O CPF deve conter apenas números e ter 11 dígitos")]
        [DisplayName("CPF")]
        public required string Cpf { get; set; }

        [Required(ErrorMessage = "O telefone é obrigatório"),
         StringLength(15, ErrorMessage = "O telefone deve ter no máximo 15 dígitos")]
        [DisplayName("Telefone")]
        public required string Telefone { get; set; }

        [Required, EmailAddress(ErrorMessage = "O e-mail deve ser um endereço de e-mail válido"),
         StringLength(100, ErrorMessage = "O e-mail deve ter no máximo 100 caracteres")]
        [DisplayName("E-mail")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "O endereço é obrigatório"),
         StringLength(200, ErrorMessage = "O endereço deve ter no máximo 200 caracteres")]
        [DisplayName("Endereço")]
        public required string Endereco { get; set; }

        [Required(ErrorMessage = "O status é obrigatório"),
         DisplayName("Status")]
        public StatusCliente Status { get; set; }
    }

    public enum StatusCliente
    {
        [Description("Ativo")]
        Ativo = 1,
        [Description("Inativo")]
        Inativo = 2,
        [Description("Bloqueado")]
        Bloqueado = 3
    }
}