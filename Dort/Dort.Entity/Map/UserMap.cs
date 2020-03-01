using Dapper.FluentMap.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dort.Entity.Map
{
    public class UserMap : EntityMap<User>
    {
        public UserMap()
        {
            Map(p => p.IsActive).ToColumn("is_active");
        }
    }
}
