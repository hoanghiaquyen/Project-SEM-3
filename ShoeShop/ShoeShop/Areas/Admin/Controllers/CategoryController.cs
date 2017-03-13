using Models.DAO;
using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoeShop.Areas.Admin.Controllers
{
    public class CategoryController : BaseController
    {
        // GET: Admin/Category
        public ActionResult Index()
        {
            var dao = new Admin_CategoryDao();
            var model = dao.ListAllCategory();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Edit(Category ca)
        {
            if (ModelState.IsValid)
            {
                var model = new Admin_CategoryDao();
                var result = model.Update(ca);
                if (result)
                    return RedirectToAction("Index", "Category");
                else
                    ModelState.AddModelError("", "Cập nhật không thành công");
            }

            return View("Index");
        }
        
       

        [HttpPost]
        public ActionResult Create(Category ca)
        {
            var dao = new Admin_CategoryDao();
            ca.ModifiedDate = DateTime.Now;
            ca.ModifiedBy = "Admin";
            ca.Status = true;
            bool id = dao.Insert(ca);
            if (id)
                return RedirectToAction("Index", "Category");
            else
                ModelState.AddModelError("", "Thêm Category không thành công");

            return View("Index");
        }



        public ActionResult Edit(long id)
        {
            var ca = new Admin_CategoryDao().ViewDetail(id);
            return View(ca);
        }
        [HttpDelete]
        public ActionResult Delete(long id)
        {
            new Admin_CategoryDao().Delete(id);
            return RedirectToAction("Index");
        }
    }
}