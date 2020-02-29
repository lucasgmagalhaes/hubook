using Dort.Enum;

namespace Dort.Entity
{
    public class Book
    {
        public virtual long Id { get; set; }
        public virtual string GoogleBookId { get; set; }
        public virtual long UserId { get; set; }
        public virtual BookStatus Status { get; set; }
    }
}
