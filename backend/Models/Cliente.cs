using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace OrdemServicoAPI.Models {
    public class Cliente {
        [Key, Required]
        public int Id { get; set; }
        
        [Required(ErrorMessage = "O nome é obrigatório"), StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres")]
        [DisplayName("Nome")]
        public string Nome { get; set; }
        
        [Required(ErrorMessage = "O CPF é obrigatório"), StringLength(11, ErrorMessage = "O CPF deve ter 11 dígitos")]
        [DisplayName("CPF")]
        public string CPF { get; set; }
        
        [Required(ErrorMessage = "O telefone é obrigatório"), StringLength(15, ErrorMessage = "O telefone deve ter no máximo 15 dígitos")]
        [DisplayName("Telefone")]
        public string Telefone { get; set; }
        
        [Required, EmailAddress(ErrorMessage = "O e-mail deve ser um endereço de e-mail válido"), StringLength(100, ErrorMessage = "O e-mail deve ter no máximo 100 caracteres")]
        [DisplayName("E-mail")]
        public string Email { get; set; }
    }	
}