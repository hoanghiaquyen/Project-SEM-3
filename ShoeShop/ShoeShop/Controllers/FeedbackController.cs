using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.DAO;
using Models.EF;

namespace ShoeShop.Controllers
{
    public class FeedbackController : Controller
    {
        // GET: Feedback
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult FeedBack(Feedback obj)
        {
            var result = new FeedbackDao().SendFeedback(obj);
            if (!result)
            {
                ViewBag.Message = "Error Feedback";
                return View();
            }
            ViewBag.Message = "Thanks you. We will reply to you soon. Wish you have a nice day";
            return View();
        }
    }
}