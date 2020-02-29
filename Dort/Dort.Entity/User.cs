using System;
using System.Collections.Generic;
using System.Text;

namespace Dort.Entity
{
    public class User
    {
        public virtual long Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Email { get; set; }
        public virtual string PhotoUrl { get; set; }
        public virtual string Password { get; set; }
        public string EmailValidated { get; set; }
        public virtual List<Book> Books { get; set; }
        public virtual UserLevel UserLevel { get; set; }
    }
}
