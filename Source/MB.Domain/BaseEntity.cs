using System;
using System.Collections.Generic;
using System.Text;

namespace MB.Domain
{
    public abstract class BaseEntity<EntityId>
    {
        public EntityId Id { get; set; }
    }
}
