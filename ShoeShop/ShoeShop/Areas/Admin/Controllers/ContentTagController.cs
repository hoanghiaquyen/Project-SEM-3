using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.DAO;

namespace ShoeShop.Areas.Admin.Controllers
{
    public class ContentTagController : BaseController
    {
        // GET: Admin/ContentTag
        public ActionResult Index()
        {
            var cTag = new Admin_ContentTagDao();
            var model = cTag.ListAllCTag();
            return View(model);
        }






        [HttpDelete]
        public ActionResult Delete(long id)
        {
            new Admin_ContentTagDao().Delete(id);
            return RedirectToAction("Index");
        }
    }
}