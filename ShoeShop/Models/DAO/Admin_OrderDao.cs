using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class Admin_OrderDao
    {
        ShoeShopDbContext db = null;
        public Admin_OrderDao()
        {
            db = new ShoeShopDbContext();
        }

        public bool Insert(Order entity)
        {
            db.Orders.Add(entity);
            db.SaveChanges();
            return true;
        }


        public bool Update(Order entity)
        {
            try
            {
                var order = db.Orders.Find(entity.Id);
                order.CreatedDate = entity.CreatedDate;
                order.CustomerId = entity.CustomerId;
                order.ShipName = entity.ShipName;
                order.ShipMobile = entity.ShipMobile;
                order.ShipAddress = entity.ShipAddress;
                order.ShipEmail = entity.ShipEmail;
                order.Status = entity.Status;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }


        public Order ViewDetail(int id)
        {
            return db.Orders.Find(id);
        }
        public IEnumerable<Order> ListAllOrders()
        {
            return db.Orders.ToList();
        }

        public bool Delete(int id)
        {
            try
            {
                var order = db.Orders.Find(id);
                db.Orders.Remove(order);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}
