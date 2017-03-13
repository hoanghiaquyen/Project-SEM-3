using Models.DAO;
using System.Collections.Generic;
using System.Web.Mvc;
using ShoeShop.Models;

namespace ShoeShop.Controllers
{
    public class HomeController : Controller
    {
        private const string CartSession = "CartSession";
        public ActionResult Index()
        {
            ViewBag.Slide = new SlideDao().ListSlides();
            var product = new ProductDao();
            ViewBag.NewProduct = product.ListNewProducts();
            ViewBag.TopHotProduct = product.ListTopHot();
            return View();
        }

        [ChildActionOnly]
        public PartialViewResult HeaderMenu()
        {
            var cart = Session[CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return PartialView(list);
        }

        [ChildActionOnly]
        public PartialViewResult Footer()
        {
            var model = new ProductCategoryDao().ListAllProductCategory();
            return PartialView(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}