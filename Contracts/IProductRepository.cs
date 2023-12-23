using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IProductRepository
    {
        Task<IReadOnlyList<Product>> GetAllWithSpecAsync(ISpecification<Product> spec);
        Task<Product> GetByIdWithSpecAsync(ISpecification<Product> spec);

        Task<IReadOnlyList<Product>> GetProductsFromClientAsync(int clientId, bool trackChanges);
        Task<Product> GetProductFromClientAsync(int clientId, int id, bool trackChanges);
        void CreateProductFromClient(int clientId, Product product);
        Task<IReadOnlyList<Product>> GetByIds(IReadOnlyList<int> ids, int clientId, bool trackChanges);
    }
}
