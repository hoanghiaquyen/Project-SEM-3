using System.Web.Mvc;
using Models.DAO;

namespace ShoeShop.Controllers
{
    public class ProductCategoryController : Controller
    {
        // GET: ProductCategory
        [ChildActionOnly]
        public ActionResult MenuProductCategory()
        {
            var model = new ProductCategoryDao().ListAllProductCategory();
            ViewBag.Category = new CategoryDao().ListAllCategory();
            return PartialView(model);
        }
    }
}