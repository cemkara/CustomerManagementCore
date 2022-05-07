using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    public class ProductCategory
    {
        [Key]
        public int ProductCategoryId { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }

        public List<ProductCategory> ProductCategories { get; set; }
    }
}
