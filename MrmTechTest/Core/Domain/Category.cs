using System.Collections.Generic;
using System.Linq;
using MrmTechTest.Core.Domain.Base;

namespace MrmTechTest.Core.Domain
{
    public class Category : Entity<long>
    {
        public Category(string name)
        {
            Name = name;
        }

        protected Category()
        {
        }

        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
        public virtual string Name { get; set; }

        public virtual void AddProduct(Product product)
        {
            if (Products.All(p => p.Id != product.Id))
                Products.Add(product);
        }
    }
}