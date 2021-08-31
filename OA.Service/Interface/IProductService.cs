using OA.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OA.Service.DTOs.Readonly;
using OA.Service.DTOs.Writeable;

namespace OA.Service.Interface
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllProductsAsync();
        Task<ProductDto> GetProductByIdAsync(int id);
        Task CreateProductAsync(ProductDtow product);
        Task UpdateProductAsync(int id, ProductDtow product);
        Task DeleteProductAsync(int id);
    }
}
