using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Service.Interface
{
    public interface IServiceManager
    {
        IProductService ProductService { get; }
    }
}
