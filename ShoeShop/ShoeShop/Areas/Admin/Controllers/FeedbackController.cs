using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.DAO;
using Models.EF;

namespace ShoeShop.Areas.Admin.Controllers
{
    public class FeedbackController : BaseController
    {
        // GET: Admin/Feedback
        public ActionResult Index()
        {
            var fb = new Admin_FeedbackDao();
            var model = fb.ListAllFeedback();
            return View(model);
        }



        

       
        [HttpDelete]
        public ActionResult Delete(long id)
        {
            new Admin_FeedbackDao().Delete(id);
            return RedirectToAction("Index");
        }

       
    }
}