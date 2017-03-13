using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
   public class Admin_ContentDao
    {
        ShoeShopDbContext db = null;
        public Admin_ContentDao()
        {
            db = new ShoeShopDbContext();

        }
        public bool Insert(Content entity)
        {
            db.Contents.Add(entity);
            db.SaveChanges();
            return true;
        }

        public bool Update(Content entity)
        {
            try
            {
                var ct = db.Contents.Find(entity.Id);
                ct.Name = entity.Name;
                ct.MetaTitle = entity.MetaTitle;
                ct.Description = entity.Description;
                ct.Images = entity.Images;
                ct.CategoryID = entity.CategoryID;
                ct.Detail = entity.Detail;
                ct.Status = entity.Status;
                ct.ModifiedDate = DateTime.Now;
                ct.CreatedBy = "admin";
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }



        }

        public Content ViewDetail(long id)
        {
            return db.Contents.Find(id);
        }

        public bool Delete(long id)
        {
            try
            {
                var ca = db.Contents.Find(id);
                db.Contents.Remove(ca);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public IEnumerable<Content> ListAllContent()
        {
            return db.Contents.ToList();
        }
    }
}
