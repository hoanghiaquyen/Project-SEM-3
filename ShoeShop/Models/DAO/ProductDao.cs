using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Linq;
using Models.EF;
using Models.ViewModel; 

namespace Models.DAO
{
    public class ProductDao
    {
        private ShoeShopDbContext db = null;

        public ProductDao()
        {
            db = new ShoeShopDbContext();
        }

        public List<Product> ListTopHot()
        {
            return db.Products.Where(x => x.TopHot != null && x.TopHot > DateTime.Now).OrderByDescending(x => x.CreatedDate).Take(6).ToList();
        }

        public List<Product> ListNewProducts()
        {
            return db.Products.OrderByDescending(x => x.CreatedDate).Take(6).ToList();
        }

        public Product ViewDetail(long id)
        {
            return db.Products.Find(id);
        }

        public List<string> ListName(string keyword)
        {
            return db.Products.Where(x => x.Name.Contains(keyword)).Select(x => x.Name).ToList();
        }

        public List<Product> AllProductsByCateId(long cateId, ref int totalRecord, int page = 1, int pageSize = 9)
        {
            totalRecord = db.Products.Count(x => x.CategoryId == cateId);
            return db.Products.Where(x => x.CategoryId == cateId).OrderByDescending(x => x.CreatedDate).Skip((page - 1) * pageSize).Take(pageSize).ToList();
        }

        public Category GetNameCategory(long cateId)
        {
            return db.Categories.Find(cateId);
        }

        public List<Product> SearchByName(string keyword, ref int totalRecord, int page = 1, int pageSize = 9)
        {
            totalRecord = db.Products.Count(x => x.Name.Contains(keyword));
            var model = db.Products.Where(x => x.Name.Contains(keyword)).OrderByDescending(x => x.CreatedDate).Skip((page - 1) * pageSize).Take(pageSize).ToList();
            return model;
        }

        public List<ProductViewModel> AllProductsByProCatId(long proCateId, ref int totalRecord, int page = 1, int pageSize = 9)
        {
            totalRecord = db.ProductCategories.Count(x => x.Id == proCateId);
            var model = (from p in db.Products
                join c in db.Categories on p.CategoryId equals c.Id
                join pc in db.ProductCategories on c.ProCateId equals pc.Id
                where pc.Id == proCateId
                select new ProductViewModel()
                {
                    Id = p.Id,
                    Images = p.Image,
                    Name = p.Name,
                    Price = p.Price,
                    MetaTitle = p.MetaTitle,
                    CreateDate = p.CreatedDate.Value,
                    ProCatName = pc.Name,
                    ProCatMetaTitle = pc.MetaTitle
                }).OrderByDescending(x => x.CreateDate).Skip((page - 1) * pageSize).Take(pageSize).ToList();
            return model;
        }

        public List<Product> FilterPrice(int? price, ref int totalRecord, int page = 1, int pageSize = 9)
        {
            totalRecord = db.Products.Count(p => p.Price <= price);
            return db.Products.Where(x => x.Price <= price).OrderByDescending(x => x.CreatedDate).Skip((page - 1) * pageSize).Take(pageSize).ToList();
        }

        public int CountFilterPrice(int price)
        {
            return db.Products.Count(x => x.Price <= price);
        }

    }
}
