using System.Web.Http;
using System.Web.Mvc;

namespace MrmTechTest.Areas.Api
{
    public class ApiAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Api";
            }
        }

        public override void RegisterArea(AreaRegistrationContext config)
        {
            config.Routes.MapHttpRoute(
                "CategoryProducts",
                "api/categories/{id}/products",
                new { controller = "CategoryProducts" });

            config.Routes.MapHttpRoute(
                "Categories",
                "api/categories",
                new { controller = "Categories" });

            config.Routes.MapHttpRoute(
                "Products",
                "api/products/{id}",
                new { controller = "Products", id = RouteParameter.Optional });
        }
    }
}