using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.EF;

namespace ShoeShop.Controllers
{
    public class ContactController : Controller
    {
        ShoeShopDbContext db = new ShoeShopDbContext();
        // GET: Contact
        public ActionResult Index()
        {
            var model = db.Contacts.SingleOrDefault();
            return View(model);
        }
    }
}