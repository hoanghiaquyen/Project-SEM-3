using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
        public class Admin_OrderDetailDao
        {
            private ShoeShopDbContext db = null;

            public Admin_OrderDetailDao()
            {
                db = new ShoeShopDbContext();
            }

            public bool Insert(OrderDetail entity)
            {
                db.OrderDetails.Add(entity);
                db.SaveChanges();
                return true;
            }

            public bool Update(OrderDetail entity)
            {
                try
                {
                    var OD = db.OrderDetails.Find(entity.ProductId);
                    OD.Quantity = entity.Quantity;
                    OD.Price = entity.Price;
                    db.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }



            }

            public OrderDetail ViewDetail(long id)
            {
                return db.OrderDetails.Find(id);
            }

            public bool Delete(long id)
            {
                try
                {
                    var OD = db.OrderDetails.Find(id);
                    db.OrderDetails.Remove(OD);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }

            }

            public IEnumerable<OrderDetail> ListAllOrderDetail()
            {
                return db.OrderDetails.ToList();
            }

        }
}
