using System.Web.Mvc;
using System.Web.Routing;

namespace ShoeShop
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "productdetail",
                url: "product-detail/{metatitle}-{id}",
                defaults: new { controller = "Product", action = "Detail", id = UrlParameter.Optional },
                namespaces: new[] { "ShoeShop.Controllers" }
            );

            routes.MapRoute(
                name: "search-keyword",
                url: "result-search",
                defaults: new { controller = "Product", action = "Search", id = UrlParameter.Optional },
                namespaces: new[] { "ShoeShop.Controllers" }
            );

            routes.MapRoute(
               name: "search-product-by-categoryId",
               url: "categoryId/{metatitle}-{cateId}",
               defaults: new { controller = "Product", action = "ListAllProductByCateId", id = UrlParameter.Optional },
               namespaces: new[] { "ShoeShop.Controllers" }
           );

            routes.MapRoute(
               name: "search-product-by-procatId",
               url: "procatId/{metatitle}-{proCateId}",
               defaults: new { controller = "Product", action = "ListAllProductByProCateId", id = UrlParameter.Optional },
               namespaces: new[] { "ShoeShop.Controllers" }
           );

            routes.MapRoute(
              name: "filter-by-price",
              url: "filter-by-price/{id}",
              defaults: new { controller = "Product", action = "FilterByPrice", id = UrlParameter.Optional },
              namespaces: new[] { "ShoeShop.Controllers" }
          );
            routes.MapRoute(
              name: "cart",
              url: "cart",
              defaults: new { controller = "ShoppingCart", action = "Index", id = UrlParameter.Optional },
              namespaces: new[] { "ShoeShop.Controllers" }
          );
            
            routes.MapRoute(
              name: "shopping-cart",
              url: "shopping-cart",
              defaults: new { controller = "ShoppingCart", action = "AddItem", id = UrlParameter.Optional },
              namespaces: new[] { "ShoeShop.Controllers" }
          );

            routes.MapRoute(
              name: "payment-shopping-cart",
              url: "payment",
              defaults: new { controller = "ShoppingCart", action = "Payment", id = UrlParameter.Optional },
              namespaces: new[] { "ShoeShop.Controllers" }
          );

            routes.MapRoute(
              name: "payment-success",
              url: "success",
              defaults: new { controller = "ShoppingCart", action = "Success", id = UrlParameter.Optional },
              namespaces: new[] { "ShoeShop.Controllers" }
          );


            //router content
            routes.MapRoute(
              name: "customer-service",
              url: "customer-service",
              defaults: new { controller = "Content", action = "CustomerService", id = UrlParameter.Optional },
              namespaces: new[] { "ShoeShop.Controllers" }
          );

            routes.MapRoute(
              name: "ordering",
              url: "ordering",
              defaults: new { controller = "Content", action = "Ordering", id = UrlParameter.Optional },
              namespaces: new[] { "ShoeShop.Controllers" }
          );

            routes.MapRoute(
              name: "payment",
              url: "payment-service",
              defaults: new { controller = "Content", action = "Payment", id = UrlParameter.Optional },
              namespaces: new[] { "ShoeShop.Controllers" }
          );

            routes.MapRoute(
              name: "shipping",
              url: "shipping",
              defaults: new { controller = "Content", action = "Shipping", id = UrlParameter.Optional },
              namespaces: new[] { "ShoeShop.Controllers" }
          );

            routes.MapRoute(
              name: "career",
              url: "career",
              defaults: new { controller = "Content", action = "Career", id = UrlParameter.Optional },
              namespaces: new[] { "ShoeShop.Controllers" }
          );
            //router feedback
            routes.MapRoute(
              name: "feedback",
              url: "feedback",
              defaults: new { controller = "Feedback", action = "Index", id = UrlParameter.Optional },
              namespaces: new[] { "ShoeShop.Controllers" }
          );

            //router about
            routes.MapRoute(
              name: "about",
              url: "about",
              defaults: new { controller = "About", action = "Index", id = UrlParameter.Optional },
              namespaces: new[] { "ShoeShop.Controllers" }
          );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "ShoeShop.Controllers" }
            );
        }
    }
}
