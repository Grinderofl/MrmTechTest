using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using Castle.Core.Internal;
using MrmTechTest.Core.Domain;
using MrmTechTest.Core.Domain.SeedData;
using Newtonsoft.Json;

namespace MrmTechTest.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MrmTechTest.Core.EntityFramework.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MrmTechTest.Core.EntityFramework.ApplicationDbContext context)
        {
            var seedModel = GetSeedModel().ToList();
            var categories = seedModel.Select(x => x.Category).Distinct().Select(s => new Category(s)).ToList();

            context.Set<Category>().AddOrUpdate(x => x.Name, categories.ToArray());

            var products = seedModel.Select(s =>
            {
                var product = new Product(s.Name, s.Description);
                product.AssignTo(categories.FirstOrDefault(c => c.Name == s.Category));
                return product;
            });
            context.Set<Product>().AddOrUpdate(x => new {x.Description, x.Name}, products.ToArray());
        }

        private IEnumerable<SeedModel> GetSeedModel()
        {
            return JsonConvert.DeserializeObject<IEnumerable<SeedModel>>(GetProductsJson());
        }

        private string GetProductsJson()
        {
            var resource = "MrmTechTest.Core.Domain.SeedData.project.json";
            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resource))
            {
                using (var reader = new StreamReader(stream, Encoding.UTF8))
                {
                    return reader.ReadToEnd();
                }
            }
        }
    }
}
