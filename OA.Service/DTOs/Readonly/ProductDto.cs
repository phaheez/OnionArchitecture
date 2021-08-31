using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Service.DTOs.Readonly
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string IpAddress { get; set; }
        public ProductDetailsDto ProductDetails { get; set; }
    }
}
