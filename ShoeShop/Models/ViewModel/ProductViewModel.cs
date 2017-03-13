using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModel
{
    public class ProductViewModel
    {
        public long Id { get; set; }
        public string Images { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public string ProCatName { get; set; }
        public string ProCatMetaTitle { get; set; }
        public string MetaTitle { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
