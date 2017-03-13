using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.DAO;

namespace ShoeShop.Areas.Admin.Controllers
{
    public class TagController : BaseController
    {
        // GET: Admin/Tag
        public ActionResult Index()
        {
            var tag = new Admin_TagDao();
            var model = tag.ListAllTag();
            return View(model);
        }






        [HttpDelete]
        public ActionResult Delete(long id)
        {
            new Admin_TagDao().Delete(id);
            return RedirectToAction("Index");
        }
    }
}