using System.Runtime.Serialization;

namespace MrmTechTest.Areas.Api.Models.Categories
{
    public class CategoryLineItem
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int ProductCount { get; set; }
    }
}