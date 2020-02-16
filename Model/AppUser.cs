using Microsoft.AspNetCore.Identity;

namespace Model.Identity
{
    public class AppUser : IdentityUser
    {
        public string Name { get; set; }
    }
}
