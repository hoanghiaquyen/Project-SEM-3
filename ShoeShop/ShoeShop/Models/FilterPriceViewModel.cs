using System.ComponentModel.DataAnnotations;

namespace ShoeShop.Models
{
    public class FilterPriceViewModel
    {
        [StringLength(250)]
        public string Name { get; set; }
        public decimal? Price { get; set; }
    }
}