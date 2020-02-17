using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class UserRequestModel
    {
        [Required]
        public string Login { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
