using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.DAO;
using Models.EF;

namespace ShoeShop.Areas.Admin.Controllers
{
    public class ProductController : BaseController
    {
        // GET: Admin/Product
        public ActionResult Index()
        {
            var pd = new Admin_ProductDao();
            var model = pd.ListAllUser();
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

       
        public ActionResult Edit(int id)
        {
            var model = new Admin_ProductDao().ViewDetail(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(Product pd )
        {
            if (ModelState.IsValid)
            {
                var dao = new Admin_ProductDao();
                pd.ModifiedDate = DateTime.Now;
                pd.ModifiedBy = "Admin";
                pd.Status = true;
                bool id = dao.Insert(pd);
                if (id)
                    return RedirectToAction("Index", "Product");
                else
                    ModelState.AddModelError("", "Thêm product không thành công");
            }

            return View("Index");
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                var model = new Admin_ProductDao();
                var result = model.Update(product);
                if (result)
                    return RedirectToAction("Index", "Product");
                else
                    ModelState.AddModelError("", "Cập nhật không thành công");
            }

            return View("Index");
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new Admin_ProductDao().Delete(id);
            return RedirectToAction("Index");
        }
    }

}