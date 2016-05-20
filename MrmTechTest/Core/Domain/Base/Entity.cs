using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MrmTechTest.Core.Domain.Base
{
    public abstract class Entity
    {
        public virtual DateTime LastModified { get; set; }
    }

    public abstract class Entity<TPk> : Entity
    {
        public virtual TPk Id { get; set; }
    }
}