using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.EF;

namespace ShoeShop.Controllers
{
    public class AboutController : Controller
    {
        private ShoeShopDbContext db = new ShoeShopDbContext();
        // GET: About
        public ActionResult Index()
        {
            var model = db.Abouts.ToList();
            return View(model);
        }
    }
}