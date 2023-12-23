using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Repository;
using Service.Contracts;
using Shared.DataTransfierObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Presentation.ModelBinder;

namespace Talabat.Presentation.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/clients/{clientId}/products")]
    public class ProductController : ControllerBase
    {
        private readonly IServiceManager _service;
        private readonly RepositoryContext _context;

        public ProductController(
            IServiceManager service,
            RepositoryContext context
            )
        {
            _service=service;
            _context=context;
        }

        [CachedAttribute(600)]
        [HttpGet]
        public async Task<IActionResult> GetProductsFromClient(int clientId)
        {
            var product = await _service.Product.GetProductsFromClientAsync(clientId, trachChanges: false);
            return Ok(product);
        }
        
        [HttpGet("brands")]
        public IActionResult GetBrands()
        {
            var brands = _context.ProductBrands.ToList();
            return Ok(brands);
        }

        [HttpGet("types")]
        public IActionResult GetTypes()
        {
            var types = _context.ProductTypes.ToList() ;
            return Ok(types);
        }

        /*[HttpGet("{productId:guid}")]
        public async Task<IActionResult> GetProductByClient(int clientId, int productId)
        {
            var productToReturn = await _service.Product.GetProductFromClientAsync(clientId, productId, trackChanges: false);
            return Ok(productToReturn);
        }

        [HttpGet("({productIds})")]
        public async Task<IActionResult> GetProductCollection(int clientId,[ModelBinder(BinderType = typeof(ArrayModelBinder))] IEnumerable<Guid> productIds)
        {
            var products = await _service.Product.GetProductsByIdsAsync(clientId, productIds, trackChanges: false);
            return Ok(products);
        }
        

        [HttpPost]
        public async Task<IActionResult> CreateProduct(int clientId, [FromBody] CreateProductDto createProduct)
        {
            var product = await _service.Product.CreateProduct(clientId, createProduct, trackChanges: false);
            return CreatedAtRoute(nameof(GetProductByClient), new { clientId, id = product.ProductId }, product);
        }

        [HttpPost("collections")]
        public async Task<IActionResult> CreateProductCollection (int clientId, [FromBody] IEnumerable<CreateProductDto> createProduct)
        {
            var products = await _service.Product.CreateProductCollection(clientId, createProduct, trackChanges: false);
            return CreatedAtRoute(nameof(GetProductCollection), new { products.ids }, products);
        }*/





    }
}
