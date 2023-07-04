using System.ComponentModel.DataAnnotations;

namespace webapi.Models
{
    public class LoginModel
    {
        public int Id { get; set; }
        [Required]
        public string? NomeUsuario { get; set; }
        [Required]
        public string? SenhaHash { get; set; }
    }
}
