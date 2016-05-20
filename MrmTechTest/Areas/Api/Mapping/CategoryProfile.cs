using AutoMapper;
using MrmTechTest.Areas.Api.Models.Categories;
using MrmTechTest.Core.Domain;

namespace MrmTechTest.Areas.Api.Mapping
{
    public class CategoryProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<Category, CategoryLineItem>()
                .ForMember(x => x.ProductCount, x => x.MapFrom(c => c.Products.Count));
        }
    }
}