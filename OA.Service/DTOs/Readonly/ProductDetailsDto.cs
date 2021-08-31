using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Service.DTOs.Readonly
{
    public class ProductDetailsDto
    {
        public int StockAvailable { get; set; }
        public decimal Price { get; set; }
        public virtual ProductDto Product { get; set; }
    }
}
