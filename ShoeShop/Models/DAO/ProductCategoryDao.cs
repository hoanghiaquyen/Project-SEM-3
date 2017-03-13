using System.Collections.Generic;
using System.Linq;
using Models.EF;

namespace Models.DAO
{
    public class ProductCategoryDao
    {
        private ShoeShopDbContext db = null;
        public ProductCategoryDao()
        {
            db = new ShoeShopDbContext();
        }

        public List<ProductCategory> ListAllProductCategory()
        {
            return db.ProductCategories.Where(x => x.Status == true).OrderBy(x => x.DisplayOrder).ToList();
        }
    }
}
