using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MrmTechTest.Areas.Api.Models.Categories;
using MrmTechTest.Core.Domain.Queries;
using MrmTechTest.Core.Infrastructure.EntityFramework;

namespace MrmTechTest.Areas.Api.Controllers
{
    public class CategoriesController : ApiController
    {
        private readonly IRepository _repository;
        private readonly IConfigurationProvider _configurationProvider;

        public CategoriesController(IRepository dbContext, IConfigurationProvider configurationProvider)
        {
            _repository = dbContext;
            _configurationProvider = configurationProvider;
        }

        // GET: /api/categories
        public IEnumerable<CategoryLineItem> Get()
        {
            var categories = _repository.Query(new FindAllCategoriesQuery());
            return categories.ProjectToList<CategoryLineItem>(_configurationProvider);
        } 
    }
}