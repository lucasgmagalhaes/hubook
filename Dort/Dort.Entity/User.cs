using System.Collections.Generic;

namespace Dort.Entity
{
    public class User : IBaseEntity<long>
    {
        public virtual long Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Email { get; set; }
        public virtual string PhotoUrl { get; set; }
        public virtual string Password { get; set; }
        public virtual int Level { get; set; }
        public virtual long Exp { get; set; }
        public virtual long LevelMaxExp { get; set; }
        public virtual bool IsActive { get; set; }
        public virtual bool IsEmailValidated { get; set; }
        public virtual List<Book> Books { get; set; }
    }
}
