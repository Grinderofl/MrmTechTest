using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using MrmTechTest.Core.Domain;
using MrmTechTest.Core.Domain.SeedData;
using MrmTechTest.Core.EntityFramework;
using Newtonsoft.Json;

namespace MrmTechTest.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ApplicationDbContext context)
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