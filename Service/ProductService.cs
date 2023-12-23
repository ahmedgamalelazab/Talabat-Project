using AutoMapper;
using AutoMapper.Configuration.Annotations;
using Contracts;
using Entities.Exceptions.AgentException;
using Entities.Exceptions.ClientException;
using Entities.Exceptions.OrderException;
using Entities.Exceptions.ProductException;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Repository;
using Service.Contracts;
using Shared.DataTransfierObject;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    internal sealed class ProductService : IProductService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        private readonly RepositoryContext _context;

        public ProductService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper, RepositoryContext context)
        {
            _repository=repository;
            _logger=logger;
            _mapper=mapper;
            _context=context;
        }

        public async Task<IReadOnlyList<ProductDto>> GetAllProducts()
        {
            var spec = new ProductWithBrandAndTypeAndClientSpecification();
            var products = await _repository.Product.GetAllWithSpecAsync(spec);
            var productToReturn = _mapper.Map<IReadOnlyList<ProductDto>>(products);
            return productToReturn;
        }

        public async Task<ProductDto> GetByIdProduct(int id)
        {
            var spec = new ProductWithBrandAndTypeAndClientSpecification(id);
            var products = await _repository.Product.GetAllWithSpecAsync(spec);
            var productToReturn = _mapper.Map<ProductDto>(products);
            return productToReturn;
        }


        public async Task<IReadOnlyList<ProductDto>> GetProductsFromClientAsync(int clientId, bool trackChanges)
        {
            var client = await _repository.Client.GetClient(clientId, trackChanges);
            if (client is null)
                throw new ClientNotFoundException(clientId);

            var products = await _repository.Product.GetProductsFromClientAsync(clientId, trackChanges);
            var productToReturn = _mapper.Map<IReadOnlyList<ProductDto>>(products);
            return productToReturn;
        }


        /*public async Task<ProductDto> GetProductFromClientAsync (Guid clientId, Guid productId, bool trackChanges)
        {
            var client = await _repository.Client.GetClient(clientId, trackChanges);
            if (client is null)
                throw new ClientNotFoundException(clientId);

            var product = await _repository.Product.GetProductFromClientAsync(clientId, productId, trackChanges);
            var productToReturn = _mapper.Map<ProductDto>(product);
            return productToReturn;
        }*/

        /*public async Task<IEnumerable<ProductDto>> GetProductsByIdsAsync(Guid clientId, IEnumerable<Guid> ids, bool trackChanges)
        {
            var client = await _repository.Client.GetClient(clientId, trackChanges);
            if (client is null)
                throw new ClientNotFoundException(clientId);
            var productEntities = await _repository.Product.GetByIds(ids, clientId, trackChanges);

            if (ids.Count() != productEntities.Count())
                throw new CollectionByIdsBadRequestException();
            var productToReturn = _mapper.Map<IEnumerable<ProductDto>>(productEntities);
            return productToReturn;
        }

        public async Task<ProductDto> CreateProduct(Guid clientId, CreateProductDto createProduct, bool trackChanges)
        {
            var client = await _repository.Client.GetClient(clientId, trackChanges);
            if (client is null)
                throw new ClientNotFoundException(clientId);

            var productEntity = _mapper.Map<Product>(createProduct);
            _repository.Product.CreateProductFromClient(clientId, productEntity);
            await _repository.SaveAsync();
            var productToReturn = _mapper.Map<ProductDto>(productEntity);
            return productToReturn;
        }

        public async Task<(IEnumerable<ProductDto> products, string ids)> CreateProductCollection(Guid clientId, 
            IEnumerable<CreateProductDto> createProduct, bool trackChanges)
        {            var client = await _repository.Client.GetClient(clientId, trackChanges);
            if (client is null)
                throw new ClientNotFoundException(clientId);

            if (createProduct is null)
                throw new ProductCollectionBadRequest();

            var productEntities = _mapper.Map<IEnumerable<Product>>(createProduct);
            foreach (var product in productEntities)
                _repository.Product.CreateProductFromClient(clientId, product);

            await _repository.SaveAsync();


            var productCollectionToReturn = _mapper.Map<IEnumerable<ProductDto>>(productEntities);
            var ids = string.Join(",", productCollectionToReturn.Select(p => p.ProductId));
            return (products: productCollectionToReturn, ids: ids);
        }
        */
    }
}
