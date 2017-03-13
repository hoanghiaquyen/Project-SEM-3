using Models.DAO;
using Models.EF;
using System.Web.Mvc;

namespace ShoeShop.Areas.Admin.Controllers
{
    public class OrderController : BaseController
    {
        // GET: Admin/Order
        public ActionResult Index()
        {
            var pd = new Admin_OrderDao();
            var model = pd.ListAllOrders();
            return View(model);
        }
        
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }


        public ActionResult Edit(int id)
        {
            var model = new Admin_OrderDao().ViewDetail(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(Order order)
        {
            if (ModelState.IsValid)
            {
                var dao = new Admin_OrderDao();
                bool id = dao.Insert(order);
                if (id)
                    return RedirectToAction("Index", "Order");
                else
                    ModelState.AddModelError("", "Thêm product không thành công");
            }

            return View("Index");
        }

        [HttpPost]
        public ActionResult Edit(Order order)
        {
            if (ModelState.IsValid)
            {
                var model = new Admin_OrderDao();
                var result = model.Update(order);
                if (result)
                    return RedirectToAction("Index", "Order");
                else
                    ModelState.AddModelError("", "Cập nhật không thành công");
            }

            return View("Index");
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new Admin_OrderDao().Delete(id);
            return RedirectToAction("Index");
        }
    }
}