using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using MrmTechTest.Areas.Api.Models.Categories;
using MrmTechTest.Core.Domain;
using MrmTechTest.Core.Domain.Queries;
using NUnit.Framework;

namespace MrmTechTest.Tests.CategoryTests
{
    public class WhenRetrievingListOfCategories : CategoryContext
    {
        private IEnumerable<CategoryLineItem> _result;

        protected override void Context()
        {
            var categories = new List<Category>()
            {
                new Category("Category 1"),
                new Category("Category 2")
            };
            RepositoryMock.Setup(x => x.Query(It.IsAny<FindAllCategoriesQuery>())).Returns(categories.AsQueryable());
        }

        protected override void Because()
        {
            _result = CategoriesController.Get();
        }

        [Test]
        public void should_retrieve()
        {
            Assert.AreEqual(2, _result.Count());
        }

        [Test]
        public void should_contain_correct_items()
        {
            Assert.AreEqual("Category 1", _result.ElementAt(0).Name);
            Assert.AreEqual("Category 2", _result.ElementAt(1).Name);
        }
    }
}
