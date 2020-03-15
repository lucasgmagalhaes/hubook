using System;

namespace Dort.Entity.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class DapperTableAttribute : Attribute
    {
        public string Name { get; }
        public DapperTableAttribute(string name) : base()
        {
            Name = name;
        }
    }
}
