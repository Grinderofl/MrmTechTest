using Moq;
using MrmTechTest.Areas.Api.Models.Products;
using MrmTechTest.Core.Domain;
using NUnit.Framework;

namespace MrmTechTest.Tests.ProductTests
{
    public class WhenCreatingProduct : ProductContext
    {
        private ProductLineItem _result;

        protected override void Context()
        {
            var product = CreateDependency<Product>();
            product.SetupGet(x => x.Id).Returns(1);
            product.SetupGet(x => x.Name).Returns("Foo");
            product.SetupGet(x => x.Description).Returns("Bar");
            ProductFactory.Setup(x => x.Create(It.IsAny<ProductFields>())).Returns(product.Object);
        }

        protected override void Because()
        {
            _result = ProductsController.Post(new ProductFields()
            {
                Name = "Foo",
                Description = "Bar",
                Category = "Baz"
            });
        }

        [Test]
        public void should_save()
        {
            RepositoryMock.Verify(x => x.Save(It.IsAny<Product>()), Times.Once);
        }

        [Test]
        public void should_return_item()
        {
            Assert.AreEqual(1, _result.Id);
            Assert.AreEqual("Foo", _result.Name);
            Assert.AreEqual("Bar", _result.Description);
        }
    }
}