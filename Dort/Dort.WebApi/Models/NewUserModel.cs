using Dort.WebApi.Attributes;

namespace Dort.WebApi.Models
{

    public class NewUserModel : LoginModel
    {
        [DortRequired]
        public string Name { get; set; }
    }
}
