namespace Dort.Entity
{
    public class UserLevel
    {
        public virtual long Id { get; set; }
        public virtual long UserId { get; set; }
        public virtual int Level { get; set; }
        public virtual long Exp { get; set; }
        public virtual long LevelMaxExp { get; set; }
    }
}
