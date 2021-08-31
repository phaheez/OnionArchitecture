using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OA.DataAccess;
using OA.Repository;
using OA.Service.DTOs.Readonly;
using OA.Service.DTOs.Writeable;
using OA.Service.Exceptions;
using OA.Service.Interface;

namespace OA.Service.Implementation
{
    public sealed class ProductService: IProductService
    {
        private readonly IRepositoryManager _repositoryManager;

        public ProductService(IRepositoryManager repositoryManager) => _repositoryManager = repositoryManager;
        
        public async Task<IEnumerable<ProductDto>> GetAllProductsAsync()
        {
            var products = await _repositoryManager.ProductRepository.GetAllProductAsync();
            var productsDto = Mapping.Mapper.Map<IEnumerable<ProductDto>>(products);
            return productsDto;
        }

        public async Task<ProductDto> GetProductByIdAsync(int id)
        {
            var product = await _repositoryManager.ProductRepository.GetProductByIdAsync(id);
            if (product is null)
            {
                throw new ProductNotFoundException(id);
            }
            var productDto = Mapping.Mapper.Map<ProductDto>(product);
            return productDto;
        }

        public async Task CreateProductAsync(ProductDtow productModel)
        {
            var product = Mapping.Mapper.Map<Product>(productModel);
            product.AddedDate = DateTime.Now;
            product.ModifiedDate = DateTime.Now;
            _repositoryManager.ProductRepository.CreateProduct(product);
            await _repositoryManager.UnitOfWork.SaveChangesAsync();
        }

        public async Task UpdateProductAsync(int id, ProductDtow productModel)
        {
            var product = await _repositoryManager.ProductRepository.GetProductByIdAsync(id);
            if (product is null)
            {
                throw new ProductNotFoundException(id);
            }

            product.ProductName = productModel.ProductName;
            product.ModifiedDate = DateTime.Now;

            await _repositoryManager.UnitOfWork.SaveChangesAsync();
        }

        public async Task DeleteProductAsync(int id)
        {
            var product = await _repositoryManager.ProductRepository.GetProductByIdAsync(id);
            if (product is null)
            {
                throw new ProductNotFoundException(id);
            }

            _repositoryManager.ProductRepository.DeleteProduct(product);
            await _repositoryManager.UnitOfWork.SaveChangesAsync();
        }
    }
}
