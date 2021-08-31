using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.DataAccess
{
    public class Product: BaseEntity
    {
        [Required(ErrorMessage = "Product Name is required")]
        [StringLength(250)]
        public string ProductName { get; set; }
        public virtual ProductDetails ProductDetails { get; set; }
    }
}
