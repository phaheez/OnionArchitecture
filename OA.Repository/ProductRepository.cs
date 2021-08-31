using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OA.DataAccess;

namespace OA.Repository
{
    public class ProductRepository: IProductRepository
    {
        private readonly RepositoryContext _context;

        public ProductRepository(RepositoryContext context) => _context = context;

        public async Task<IEnumerable<Product>> GetAllProductAsync() =>
            await _context.Products.Include(p => p.ProductDetails)
                .OrderBy(p => p.AddedDate)
                .ToListAsync();

        public async Task<Product> GetProductByIdAsync(int id) => 
            await _context.Products.Include(p => p.ProductDetails)
            .FirstOrDefaultAsync(p => p.Id == id);

        public void CreateProduct(Product product) => _context.Products.Add(product);

        public void UpdateProduct(Product product) => _context.Products.Update(product);

        public void DeleteProduct(Product product) => _context.Products.Remove(product);
    }
}
