using AutoMapper;
using MrmTechTest.Areas.Api.Models.Products;
using MrmTechTest.Core.Domain;

namespace MrmTechTest.Areas.Api.Mapping
{
    public class ProductProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<Product, ProductLineItem>();
        }
    }
}