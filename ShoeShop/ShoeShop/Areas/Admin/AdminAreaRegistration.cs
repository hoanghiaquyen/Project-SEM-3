using System.Web.Mvc;

namespace ShoeShop.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            
           

            context.MapRoute(
               "Admin_ProductEdit",
               "Admin/{controller}/{action}/{id}",
               new { controller = "Product", action = "Edit", id = UrlParameter.Optional },
               namespaces: new[] { "ShoeShop.Areas.Admin.Controllers" }
           );
            context.MapRoute(
               "Admin_default",
               "Admin/{controller}/{action}/{id}",
               new { controller = "Home", action = "Index", id = UrlParameter.Optional },
               namespaces: new[] { "ShoeShop.Areas.Admin.Controllers" }
           );
        }
    }
}