using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
   public class Admin_TagDao
    {
        ShoeShopDbContext db = null;
        public Admin_TagDao()
        {
            db = new ShoeShopDbContext();
        }
        

        

        public Tag ViewDetail(long id)
        {
            return db.Tags.Find(id);
        }

        public bool Delete(long id)
        {
            try
            {
                var tag = db.Tags.Find(id);
                db.Tags.Remove(tag);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public IEnumerable<Tag> ListAllTag()
        {
            return db.Tags.ToList();
        }
    }
}
