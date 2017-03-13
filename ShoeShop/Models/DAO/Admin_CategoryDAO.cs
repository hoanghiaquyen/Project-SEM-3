using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class Admin_CategoryDao
    {
        ShoeShopDbContext db = null;
        public Admin_CategoryDao()
        {
            db = new ShoeShopDbContext();
        }
        public bool Insert(Category entity)
        {
            db.Categories.Add(entity);
            db.SaveChanges();
            return true;
        }

        public bool Update(Category entity)
        {
            try
            {
                var ca = db.Categories.Find(entity.Id);
                ca.Name = entity.Name;
                ca.MetaTitle = entity.MetaTitle;
                ca.ParentID = entity.ParentID;
                ca.ProCateId = entity.ProCateId;
                ca.DisplayOrder = entity.DisplayOrder;
                ca.ImageCategory = entity.ImageCategory;
                ca.Status = entity.Status;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }



        }

        public Category ViewDetail(long id)
        {
            return db.Categories.Find(id);
        }

        public bool Delete(long id)
        {
            try
            {
                var ca = db.Categories.Find(id);
                db.Categories.Remove(ca);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public IEnumerable<Category> ListAllCategory()
        {
            return db.Categories.ToList();
        }


    }
}
