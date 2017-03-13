using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.DAO;
using Models.EF;

namespace ShoeShop.Areas.Admin.Controllers
{
    public class OrderDetailsController : BaseController
    {
        // GET: Admin/OrderDetalis
        public ActionResult Index()
        {
            var model = new Admin_OrderDetailDao().ListAllOrderDetail();
            return View(model);
        }



       

        
        [HttpDelete]
        public ActionResult Delete(long id)
        {
            new Admin_OrderDetailDao().Delete(id);
            return RedirectToAction("Index");
        }

       
    }
}