using System.Web.Http;
using Moq;
using MrmTechTest.Core.Domain;
using NUnit.Framework;

namespace MrmTechTest.Tests.ProductTests
{
    public class WhenDeletingProductAndProductDoesNotExist : ProductContext
    {
        public TestDelegate DeleteMethod;
        protected override void Context()
        {
            RepositoryMock.Setup(x => x.Find<Product>(It.IsAny<object>())).Returns((Product) null);
        }

        protected override void Because()
        {
            DeleteMethod = () => ProductsController.Delete(1);
        }

        [Test]
        public void should_throw_exception()
        {
            Assert.Throws<HttpResponseException>(DeleteMethod);
        }

        [Test]
        public void should_not_delete()
        {
            RepositoryMock.Verify(x => x.Delete(It.IsAny<object>()), Times.Never);
        }
    }
}