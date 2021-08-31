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
    public sealed class ProductService : IProductService
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

        public async Task CreateProductAsync(ProductDtow productModel, string ipAddress)
        {
            //var product = Mapping.Mapper.Map<Product>(productModel);
            var curDate = DateTime.UtcNow;
            var product = new Product
            {
                ProductName = productModel.ProductName,
                IpAddress = ipAddress,
                AddedDate = curDate,
                ModifiedDate = curDate,
                ProductDetails = new ProductDetails
                {
                    AddedDate = curDate,
                    ModifiedDate = curDate,
                    Price = Convert.ToDecimal(productModel.Price),
                    StockAvailable = productModel.StockAvailable,
                    IpAddress = ipAddress
                }
            };
            _repositoryManager.ProductRepository.CreateProduct(product);
            await _repositoryManager.UnitOfWork.SaveChangesAsync();
        }

        public async Task UpdateProductAsync(int id, ProductDtow productModel, string ipAddress)
        {
            var product = await _repositoryManager.ProductRepository.GetProductByIdAsync(id);
            if (product is null)
            {
                throw new ProductNotFoundException(id);
            }

            var modifiedDate = DateTime.UtcNow;

            product.ProductName = productModel.ProductName;
            product.IpAddress = ipAddress;
            product.ModifiedDate = modifiedDate;

            product.ProductDetails.Price = Convert.ToDecimal(productModel.Price);
            product.ProductDetails.StockAvailable = productModel.StockAvailable;
            product.ProductDetails.ModifiedDate = modifiedDate;
            product.ProductDetails.IpAddress = ipAddress;

            _repositoryManager.ProductRepository.UpdateProduct(product);
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
