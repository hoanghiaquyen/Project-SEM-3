using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class Admin_ProductDao
    {
        ShoeShopDbContext db = null;
        public Admin_ProductDao()
        {
            db = new ShoeShopDbContext();
        }

        public bool Insert(Product entity)
        {
            db.Products.Add(entity);
            db.SaveChanges();
            return true;
        }


        public bool Update(Product entity)
        {
            try
            {
                var product = db.Products.Find(entity.Id);
                product.Name = entity.Name;
                product.Code = entity.Code;
                product.MetaTitle = entity.MetaTitle;
                product.Image = entity.Image;
                product.Price = entity.Price;
                product.Warranty = entity.Warranty;               
                product.Description = entity.Description;
                product.Detail = entity.Detail;
                product.Status = entity.Status;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

      
        public Product ViewDetail(int id)
        {
            return db.Products.Find(id);
        }
        public IEnumerable<Product> ListAllUser()
        {
            return db.Products.ToList();
        }
       
        public bool Delete(int id)
        {
            try
            {
                var product = db.Products.Find(id);
                db.Products.Remove(product);
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
