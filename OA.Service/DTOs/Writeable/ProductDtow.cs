using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Service.DTOs.Writeable
{
    public class ProductDtow
    {
        public string ProductName { get; set; }
        public double Price { get; set; }
        public int StockAvailable { get; set; }
    }
}
