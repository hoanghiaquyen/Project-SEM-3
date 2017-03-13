using Models.EF;

namespace Models.DAO
{
    public class OrderDao
    {
        private ShoeShopDbContext db = null;

        public OrderDao()
        {
            db = new ShoeShopDbContext();
        }
        public long Insert(Order order)
        {
            db.Orders.Add(order);
            db.SaveChanges();
            return order.Id;
        }
    }
}
