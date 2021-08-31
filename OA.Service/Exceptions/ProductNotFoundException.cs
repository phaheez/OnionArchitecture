using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Service.Exceptions
{
    public sealed class ProductNotFoundException: NotFoundException
    {
        public ProductNotFoundException(int id) : base($"No Record Found for ProductId {id}") { }
    }
}
