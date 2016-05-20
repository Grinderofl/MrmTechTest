using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace MrmTechTest.Areas.Api.Models.Products
{
    public class ProductLineItem
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string CategoryName { get; set; }
    }
}