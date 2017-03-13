using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Models.DAO;
using Models.EF;
using ShoeShop.Models;

namespace ShoeShop.Controllers
{
    public class ShoppingCartController : Controller
    {
        private const string CartSession = "CartSession";
        // GET: ShoppingCart
        public ActionResult Index()
        {
            var cart = Session[CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>) cart;
            }
            var total = (decimal)0.0;
            foreach (var item in list)
            {
                if (item.Product.PromotionPrice != null)
                {
                    var proprice = Convert.ToDecimal(item.Product.PromotionPrice);
                    total += Convert.ToDecimal((proprice*item.Quantity).ToString("N"));
                }
                else
                {
                    var price = Convert.ToDecimal(item.Product.Price);
                    total += Convert.ToDecimal((price * item.Quantity).ToString("N"));
                }
            }
            ViewBag.TotalMoney = total;
            return View(list);
        }

        public ActionResult AddItem(long productId, int quantity)
        {
            var Product = new ProductDao().ViewDetail(productId);
            var cart = Session[CartSession];
            if (cart != null)
            {
                var list = (List<CartItem>) cart;
                if (list.Exists(x => x.Product.Id == productId))
                {
                    foreach (var item in list.Where(item => item.Product.Id == productId))
                    {
                        item.Quantity += quantity;
                    }
                }
                else
                {
                    var item = new CartItem();
                    item.Product = Product;
                    item.Quantity = quantity;
                    list.Add(item);
                }
                
            }
            else
            {
                var item = new CartItem
                {
                    Product = Product,
                    Quantity = quantity
                };
                var list = new List<CartItem> {item};

                Session[CartSession] = list;

            }
            return RedirectToAction("Index");
        }

        public JsonResult Update(string cartModel)
        {
            var jsonCart = new JavaScriptSerializer().Deserialize<List<CartItem>>(cartModel);
            var sessionCart = (List<CartItem>)Session[CartSession];

            foreach (var item in sessionCart)
            {
                var jsonItem = jsonCart.SingleOrDefault(x => x.Product.Id == item.Product.Id);
                if (jsonItem != null)
                {
                    item.Quantity = jsonItem.Quantity;
                }
            }
            Session[CartSession] = sessionCart;
            return Json(new
            {
                status=true
            });
        }

        public JsonResult DeleteAll()
        {
            Session[CartSession] = null;
            return Json(new
            {
                status = true
            });
        }

        public JsonResult Delete(long id)
        {
            var sessionCart = (List<CartItem>)Session[CartSession];
            sessionCart.RemoveAll(x => x.Product.Id == id);
            Session[CartSession] = sessionCart;
            return Json(new
            {
                status = true
            });
        }

        public ActionResult Payment()
        {
            if (Session[Common.CommonConstants.USER_SESSION] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            var cart = Session[CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            var total = (decimal)0.0;
            foreach (var item in list)
            {
                if (item.Product.PromotionPrice != null)
                {
                    var proprice = Convert.ToDecimal(item.Product.PromotionPrice);
                    total += Convert.ToDecimal((proprice * item.Quantity).ToString("N"));
                }
                else
                {
                    var price = Convert.ToDecimal(item.Product.Price);
                    total += Convert.ToDecimal((price * item.Quantity).ToString("N"));
                }
            }
            ViewBag.TotalMoney = total;
            return View(list);
        }

        [HttpPost]
        public ActionResult Payment(string txtShipName, string txtPhone, string txtAddress, string txtEmail, string txtTotalPayment)
        {
            var order = new Order
            {
                CreatedDate = DateTime.Now,
                ShipName = txtShipName,
                ShipMobile = txtPhone,
                ShipAddress = txtAddress,
                ShipEmail = txtEmail,
                Total = Convert.ToDecimal(txtTotalPayment)
            };
            try
            {
                var idOrder = new OrderDao().Insert(order);
                var cart = (List<CartItem>)Session[CartSession];
                var detailDao = new OrderDetailDao();

                foreach (var orderDetail in cart.Select(item => new OrderDetail
                {
                    ProductId = item.Product.Id,
                    OrderId = idOrder,
                    Price = item.Product.Price,
                    Quantity = item.Quantity
                }))
                {
                    detailDao.Insert(orderDetail);
                }
            }
            catch (Exception)
            {
                //write log
                Redirect("/ErrorPayment");
            }
            return Redirect("/Success");
        }

        public ActionResult Success()
        {
            Session[CartSession] = null;
            return View();
        }
    }
}