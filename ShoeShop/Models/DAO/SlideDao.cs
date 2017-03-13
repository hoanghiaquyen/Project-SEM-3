﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.EF;

namespace Models.DAO
{
    public class SlideDao
    {
        private ShoeShopDbContext db = null;

        public SlideDao()
        {
            db = new ShoeShopDbContext();
        }

        public List<Slide> ListSlides()
        {
            return db.Slides.Where(x => x.Status == true).OrderBy(y => y.DisplayOrder).ToList();
        } 
    }
}
