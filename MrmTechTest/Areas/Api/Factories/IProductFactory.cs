using MrmTechTest.Areas.Api.Models.Products;
using MrmTechTest.Core.Domain;

namespace MrmTechTest.Areas.Api.Factories
{
    public interface IProductFactory
    {
        Product Create(ProductFields fields);
    }
}
