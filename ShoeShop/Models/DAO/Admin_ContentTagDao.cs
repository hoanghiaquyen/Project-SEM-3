using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class Admin_ContentTagDao
    {
        ShoeShopDbContext db = null;
        public Admin_ContentTagDao()
        {
            db = new ShoeShopDbContext();
        }




        public ContentTag ViewDetail(long id)
        {
            return db.ContentTags.Find(id);
        }

        public bool Delete(long id)
        {
            try
            {
                var cTag = db.ContentTags.Find(id);
                db.ContentTags.Remove(cTag);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public IEnumerable<ContentTag> ListAllCTag()
        {
            return db.ContentTags.ToList();
        }
    }
}
