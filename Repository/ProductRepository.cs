using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ProductRepository : RepositoryBase<Product> ,IProductRepository
    {
        private readonly RepositoryContext _context;

        public ProductRepository(RepositoryContext context) : base(context)
        {
            _context=context;
        }
        public async Task<IReadOnlyList<Product>> GetProductsFromClientAsync(int clientId, bool trackChanges)
        {
            var product = await FindByCondition(c => c.ClientId.Equals(clientId), trackChanges, new List<Expression<Func<Product,object>>> {p=> p.ProductBrand,p => p.ProductType })
                .OrderBy(p => p.Name).ToListAsync();
            return product;
        }


        public async Task<Product> GetProductFromClientAsync(int clientId, int id, bool trackChanges)
            => await FindByCondition(c => c.ClientId.Equals(clientId) && c.Id.Equals(id), trackChanges, new List<Expression<Func<Product,object>>> { p => p.ProductBrand, p => p.ProductType})
                .SingleOrDefaultAsync();


        public async Task<IReadOnlyList<Product>> GetByIds(IReadOnlyList<int> ids, int clientId, bool trackChanges)
            => await FindByCondition(c => c.ClientId.Equals(clientId) && ids.Contains(c.Id), trackChanges).ToListAsync();

        public void CreateProductFromClient(int clientId, Product product)
        {
            product.ClientId = clientId;
            CreateAsync(product);
        }

        public async Task<IReadOnlyList<Product>> GetAllWithSpecAsync(ISpecification<Product> spec)
        {
            return await ApplySpecification(spec).ToListAsync();
        }

        public async Task<Product> GetByIdWithSpecAsync(ISpecification<Product> spec)
        {
            return await ApplySpecification(spec).FirstOrDefaultAsync();
        }

        private IQueryable<Product> ApplySpecification(ISpecification<Product> spec)
        {
            return SpecificationEvaluator<Product>.GetQuery(_context.Set<Product>(), spec);
        }

        
    }
}
