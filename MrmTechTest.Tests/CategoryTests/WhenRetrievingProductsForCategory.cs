using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using MrmTechTest.Areas.Api.Models.Products;
using MrmTechTest.Core.Domain;
using MrmTechTest.Core.Domain.Queries;
using NUnit.Framework;

namespace MrmTechTest.Tests.CategoryTests
{
    public class WhenRetrievingProductsForCategory : CategoryProductsContext
    {
        private IEnumerable<ProductLineItem> _result;
        protected override void Context()
        {
            var category = new Category("Category");
            var product1 = new Product("Product 1", "Description 1");
            product1.AssignTo(category);

            var product2 = new Product("Product 2", "Description 2");
            product2.AssignTo(category);

            var products = new List<Product>()
            {
                product1,
                product2
            };

            RepositoryMock.Setup(x => x.Find<Category>(It.Is<long>(l => l == 1))).Returns(category);
            RepositoryMock.Setup(x => x.Query(It.IsAny<FindProductsByCategoryQuery>())).Returns(products.AsQueryable());
        }

        protected override void Because()
        {
            _result = Controller.Get(1);
        }

        [Test]
        public void should_retrieve()
        {
            Assert.AreEqual(2, _result.Count());
        }

        [Test]
        public void should_contain_correct_items()
        {
            Assert.AreEqual("Product 1", _result.ElementAt(0).Name);
            Assert.AreEqual("Product 2", _result.ElementAt(1).Name);
        }
    }
}