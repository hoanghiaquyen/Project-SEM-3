using System.Linq;
using Models.EF;
using System.Collections.Generic;

namespace Models.DAO
{
    public class ContentDao
    {
        private ShoeShopDbContext db = null;

        public ContentDao()
        {
            db = new ShoeShopDbContext();
        }
        public List<Content> ContentCatId(long cateId)
        {
            return db.Contents.Where(x => x.CategoryID == cateId).OrderByDescending(x => x.CreatedDate).ToList();
        }
    }
}
