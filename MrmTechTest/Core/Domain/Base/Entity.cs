using System;

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