
using Model.Dao;
using Models.EF;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ShoeShop.Areas.Admin.Controllers
{

    public class HomeController : BaseController
    {

        // GET: Admin/Home
        public ActionResult Index()
        {

            return View();
        }

        [ChildActionOnly]
        [OutputCache(Duration = 3600 * 24)]
        public ActionResult _mainNavigation()
        {
            List<object> modelMenu = new List<object>();
            List<Menu> listMenu = new MenuDao().ListByGroupId(3);
            modelMenu.Add(listMenu);

            return PartialView(modelMenu);
        }

        [ChildActionOnly]
        [OutputCache(Duration = 3600 * 24)]
        public ActionResult _mainHeader()
        {
            return PartialView();
        }
        public ActionResult Logout()
        {
            Session["USER_SESSION"] = null;
            return PartialView("Index", "Account");
        }
    }
}