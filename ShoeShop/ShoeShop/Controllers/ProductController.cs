using System;
using System.Web.Mvc;
using Models.DAO;

namespace ShoeShop.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Detail(long id)
        {
            var model = new ProductDao().ViewDetail(id);
            ViewBag.Price50 = new ProductDao().CountFilterPrice(50);
            ViewBag.Price100 = new ProductDao().CountFilterPrice(100);
            ViewBag.Price200 = new ProductDao().CountFilterPrice(200);
            ViewBag.Price300 = new ProductDao().CountFilterPrice(300);
            ViewBag.Price400 = new ProductDao().CountFilterPrice(400);
            return View(model);
        }

        public ActionResult Search(string keyword, int page = 1, int pageSize = 9)
        {
            ViewBag.Price50 = new ProductDao().CountFilterPrice(50);
            ViewBag.Price100 = new ProductDao().CountFilterPrice(100);
            ViewBag.Price200 = new ProductDao().CountFilterPrice(200);
            ViewBag.Price300 = new ProductDao().CountFilterPrice(300);
            ViewBag.Price400 = new ProductDao().CountFilterPrice(400);

            var totalRecord = 0;
            var model = new ProductDao().SearchByName(keyword, ref totalRecord, page, pageSize);
            var totalPage = (int)Math.Ceiling((double)totalRecord / pageSize);
            var maxPage = 50;

            ViewBag.SearchByName = keyword.ToUpper();

            ViewBag.MaxPage = maxPage;
            ViewBag.Total = totalRecord;
            ViewBag.Page = page;

            ViewBag.First = 1;
            ViewBag.Last = totalPage;
            ViewBag.Next = page + 1;
            ViewBag.Prev = page - 1;
            ViewBag.TotalPage = totalPage;

            return View(model);
        }

        public JsonResult ListName(string q)
        {
            var data = new ProductDao().ListName(q);
            return Json(new
            {
                data,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ListAllProductByCateId(long cateId, int page = 1, int pageSize = 9)
        {
            ViewBag.Price50 = new ProductDao().CountFilterPrice(50);
            ViewBag.Price100 = new ProductDao().CountFilterPrice(100);
            ViewBag.Price200 = new ProductDao().CountFilterPrice(200);
            ViewBag.Price300 = new ProductDao().CountFilterPrice(300);
            ViewBag.Price400 = new ProductDao().CountFilterPrice(400);

            var totalRecord = 0;
            var model = new ProductDao().AllProductsByCateId(cateId,ref totalRecord,page,pageSize);
            ViewBag.Cate = new ProductDao().GetNameCategory(cateId);

            var totalPage = (int)Math.Ceiling((double)totalRecord / pageSize);
            var maxPage = 50;

            ViewBag.MaxPage = maxPage;
            ViewBag.Total = totalRecord;
            ViewBag.Page = page;

            ViewBag.First = 1;
            ViewBag.Last = totalPage;
            ViewBag.Next = page + 1;
            ViewBag.Prev = page - 1;
            ViewBag.TotalPage = totalPage;
            return View(model);
        }

        public ActionResult ListAllProductByProCateId(long proCateId, int page = 1, int pageSize = 9)
        {
            ViewBag.Price50 = new ProductDao().CountFilterPrice(50);
            ViewBag.Price100 = new ProductDao().CountFilterPrice(100);
            ViewBag.Price200 = new ProductDao().CountFilterPrice(200);
            ViewBag.Price300 = new ProductDao().CountFilterPrice(300);
            ViewBag.Price400 = new ProductDao().CountFilterPrice(400);

            var totalRecord = 0;
            var model = new ProductDao().AllProductsByProCatId(proCateId,ref totalRecord, page, pageSize);

            var totalPage = (int)Math.Ceiling((double)totalRecord / pageSize);
            var maxPage = 50;

            ViewBag.MaxPage = maxPage;
            ViewBag.Total = totalRecord;
            ViewBag.Page = page;

            ViewBag.First = 1;
            ViewBag.Last = totalPage;
            ViewBag.Next = page + 1;
            ViewBag.Prev = page - 1;
            ViewBag.TotalPage = totalPage;

            return View(model);
        }
        [HttpPost]
        public JsonResult FilterPrice(int id)
        {
            //ShoeShopDbContext db = new ShoeShopDbContext();
          
            //var listProduct =
            //    from i in db.Products
            //        where i.Price <=id
            //        orderby i.CreatedDate descending
            //        select new FilterPriceViewModel { Name = i.Name, Price = (decimal) i.Price};
            var listProduct = new ProductDao().CountFilterPrice(id);
            if (listProduct > 0)
            {
                return Json(new
                {
                    status = true,
                    data = id
                }, JsonRequestBehavior.AllowGet);
            }
            return Json(new
            {
                status = false
            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult FilterByPrice(int? id, int page = 1, int pageSize = 9)
        {
            if (id == null)
            {
                ViewBag.Message = "No product by price";
                return RedirectToAction("NoProduct","Product");
            }
            ViewBag.Price50 = new ProductDao().CountFilterPrice(50);
            ViewBag.Price100 = new ProductDao().CountFilterPrice(100);
            ViewBag.Price200 = new ProductDao().CountFilterPrice(200);
            ViewBag.Price300 = new ProductDao().CountFilterPrice(300);
            ViewBag.Price400 = new ProductDao().CountFilterPrice(400);

            var totalRecord = 0;
            var listProduct = new ProductDao().FilterPrice(id, ref totalRecord, page, pageSize);
            var model = listProduct;

            var totalPage = (int)Math.Ceiling((double)totalRecord / pageSize);
            var maxPage = 50;

            ViewBag.MaxPage = maxPage;
            ViewBag.Total = totalRecord;
            ViewBag.Page = page;

            ViewBag.First = 1;
            ViewBag.Last = totalPage;
            ViewBag.Next = page + 1;
            ViewBag.Prev = page - 1;
            ViewBag.TotalPage = totalPage;

            ViewBag.FilterByPrice = id;
            return View(model);
        }

        public ActionResult NoProduct()
        {
            return View();
        }
    }
}