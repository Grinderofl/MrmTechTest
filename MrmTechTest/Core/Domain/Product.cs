using System;
using System.Web;
using MrmTechTest.Core.Domain.Base;

namespace MrmTechTest.Core.Domain
{
    public class Product : Entity<long>
    {
        protected Product()
        {
            
        }
        public Product(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public virtual string Name { get; protected set; }
        public virtual string Description { get; protected set; }
        public virtual Category Category { get; protected set; }

        public virtual void AssignTo(Category category)
        {
            Category = category;
        }
    }
}