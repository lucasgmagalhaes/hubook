using System.ComponentModel.DataAnnotations;

namespace Dort.WebApi.Models
{
    public class LoginModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MinLength(6)]
        [MaxLength(20)]
        public string Password { get; set; }
    }
}
