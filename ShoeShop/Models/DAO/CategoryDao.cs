using System.Collections.Generic;
using System.Linq;
using Models.EF;

namespace Models.DAO
{
    public class CategoryDao
    {
        ShoeShopDbContext db = null;

        public CategoryDao()
        {
            db = new ShoeShopDbContext();
        }

        public List<Category> ListAllCategory()
        {
            return db.Categories.Where(x => x.Status == true).OrderBy(x => x.DisplayOrder).ToList();
        } 
    }
}
