using System.Web.Mvc;
using Models.DAO;
using ShoeShop.Common;

namespace ShoeShop.Controllers
{
    public class ContentController : Controller
    {
        // GET: Content
        public ActionResult Shipping()
        {
            var model = new ContentDao().ContentCatId(Constants.IdShipping);
            return View(model);
        }

        public ActionResult Ordering()
        {
            var model = new ContentDao().ContentCatId(Constants.IdOrdering);
            return View(model);
        }

        public ActionResult Payment()
        {
            var model = new ContentDao().ContentCatId(Constants.IdPayment);
            return View(model);
        }

        public ActionResult Career()
        {
            var model = new ContentDao().ContentCatId(Constants.IdCareer);
            return View(model);
        }
    }
}