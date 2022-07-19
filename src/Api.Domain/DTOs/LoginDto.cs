using System.ComponentModel.DataAnnotations;

namespace Api.Domain.DTOs
{
    public class LoginDto
    {
        [Required(ErrorMessage = "Email é OBRIGATÓRIO para o Login!")]
        [EmailAddress(ErrorMessage = "Email em formato INVÁLIDO!")]
    [StringLength(100, ErrorMessage = "Email deve ter no máximo {1} caracteres!")]
        public string Email { get; set; }
    }
}
