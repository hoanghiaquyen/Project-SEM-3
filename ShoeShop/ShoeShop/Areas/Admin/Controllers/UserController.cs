
using Model.Dao;
using Models.EF;
using ShoeShop.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoeShop.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        // GET: Admin/User
        public ActionResult Index()
        {
            var dao = new UserDao();
            var model = dao.ListAllUser();
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Edit(string id)
        {
            var user = new UserDao().ViewDetail(id);
            return View(user);
        }
        [HttpPost]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                var encriptedMD5Pass = Encryptor.MD5Hash(user.PasswordHash);
                user.PasswordHash = encriptedMD5Pass;
                user.EmailConfirmed = false;
                user.PhoneNumberConfirmed = false;
                user.LockoutEnabled = true;
                user.LockoutEndDateUtc = DateTime.Now;
                user.AccessFailedCount = 0;
                bool id = dao.Insert(user);
                if (id)
                    return RedirectToAction("Index", "User");
                else
                    ModelState.AddModelError("", "Thêm user không thành công");
            }

            return View("Index");
        }
        [HttpPost]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                bool result = dao.Update(user);
                if (result)
                    return RedirectToAction("Index", "User");
                else
                    ModelState.AddModelError("", "Cập nhật không thành công");
            }

            return View("Index");
        }

        [HttpDelete]
        public ActionResult Delete(string id)
        {
            new UserDao().Delete(id);
            return RedirectToAction("Index");
        }
    }
}