using Moq;
using MrmTechTest.Core.Domain;
using NUnit.Framework;

namespace MrmTechTest.Tests.ProductTests
{
    public class WhenDeletingProduct : ProductContext
    {
        protected override void Context()
        {
            var product = new Product("Product", "Description");
            RepositoryMock.Setup(x => x.Find<Product>(It.IsAny<object>())).Returns(product);
            base.Context();
        }

        protected override void Because()
        {
            ProductsController.Delete(1);
        }

        [Test]
        public void should_delete()
        {
            RepositoryMock.Verify(x => x.Delete(It.Is<Product>(p => p.Description == "Description")), Times.Once);
        }
    }
}