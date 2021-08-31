using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OA.Service.DTOs.Writeable;
using OA.Service.Interface;

namespace OA.API.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        public ProductsController(IServiceManager serviceManager) => _serviceManager = serviceManager;

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            try
            {
                var products = await _serviceManager.ProductService.GetAllProductsAsync();
                return Ok(products);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _serviceManager.ProductService.GetProductByIdAsync(id);
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] ProductDtow model)
        {
            try
            {
                var ipAddress = await GetIpAddress();

                model.IpAddress ??= ipAddress;

                await _serviceManager.ProductService.CreateProductAsync(model);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, ProductDtow model)
        {
            try
            {
                var ipAddress = await GetIpAddress();

                model.IpAddress ??= ipAddress;

                await _serviceManager.ProductService.UpdateProductAsync(id, model);
                return Ok("Updated");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            try
            {
                await _serviceManager.ProductService.DeleteProductAsync(id);
                return Ok("Deleted");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private async Task<string> GetIpAddress()
        {
            var remoteIpAddress = Request.HttpContext.Connection.RemoteIpAddress;
            var result = "";
            if (remoteIpAddress != null)
            {
                // If we got an IPV6 address, then we need to ask the network for the IPV4 address 
                // This usually only happens when the browser is on the same machine as the server.
                if (remoteIpAddress.AddressFamily == System.Net.Sockets.AddressFamily.InterNetworkV6)
                {
                    remoteIpAddress = (await Dns.GetHostEntryAsync(remoteIpAddress)).AddressList
                        .First(x => x.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork);
                }
                result = remoteIpAddress.ToString();
            }
            return result;
        }
    }
}
