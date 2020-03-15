using Dort.Entity.Attributes;
using System.Collections.Generic;

namespace Dort.Entity
{
    [DapperTable("UserApp")]
    public class User : IBaseEntity<long>
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string ProfileImgUrl { get; set; }
        public string Password { get; set; }
        public int Level { get; set; }
        public long Exp { get; set; }
        public long LevelMaxExp { get; set; }
        public bool IsActive { get; set; }
        public bool IsEmailValidated { get; set; }
        public List<Book> Books { get; set; }
    }
}
