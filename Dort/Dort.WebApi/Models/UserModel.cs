using Dort.WebApi.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Dort.WebApi.Models
{

    public class UserModel
    {
        [DortRequired]
        public string Name { get; set; }

        [DortRequired]
        [EmailAddress]
        public string Email { get; set; }

        [DortRequired]
        [MinLength(3)]
        public string Password { get; set; }
    }
}
