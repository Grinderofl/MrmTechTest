using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using MrmTechTest.Areas.Api.Models.Products;
using MrmTechTest.Core.Domain;
using MrmTechTest.Core.Domain.Queries;
using NUnit.Framework;

namespace MrmTechTest.Tests.FactoryTests
{
    public class WhenCreatingProductAndTheCategoryExists : ProductFactoryContext
    {
        private Product _product;
        private ProductFields _productFields;
        private Category _category;

        protected override void Context()
        {
            _category = new Category("TestCategory");
            RepositoryMock.Setup(x => x.Query(It.Is<FindCategoryByNameQuery>(c => c.Name == "TestCategory")))
                .Returns(_category);
        }

        protected override void Because()
        {
            _productFields = new ProductFields()
            {
                Category = "TestCategory",
                Description = "TestDescription",
                Name = "TestProduct"
            };
            _product = ProductFactory.Create(_productFields);
        }

        [Test]
        public void should_assign_to_category()
        {
            Assert.AreSame(_category, _product.Category);
        }

        [Test]
        public void should_set_properties()
        {
            Assert.AreEqual(_productFields.Description, _product.Description);
            Assert.AreEqual(_productFields.Name, _product.Name);
        }
    }
}
