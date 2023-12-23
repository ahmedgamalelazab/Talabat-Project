using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Extentions;
using Shared.RequestFeature;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public sealed class ClientRepository : RepositoryBase<Client>, IClientRepository
    {
        private readonly RepositoryContext _context;

        public ClientRepository(RepositoryContext context): base(context)
        {
            _context = context;
        }


        public async Task<PagedList<Client>> GetAllClients(CLientParameter cLientParameter, bool trackChanges)
        {
            var clients = await FindAllWithListOfExpression(trackChanges, 
                    new List<Expression<Func<Client, object>>> { c => c.ClientType})
                .Search(cLientParameter.SearchTerm)
                .Skip((cLientParameter.PageNumber - 1) * cLientParameter.PageSize)
                .Take(cLientParameter.PageSize)
                .OrderBy(c => c.Name)
                .ToListAsync();

            var count = await FindAll(trackChanges).CountAsync();

            return new PagedList<Client>
                (clients, count, cLientParameter.PageSize, cLientParameter.PageNumber);
        }

        public async Task<Client> GetClient(int id, bool trackChanges)
        {
            return await FindByCondition(a => a.Id.Equals(id), trackChanges, new List<Expression<Func<Client, object>>> 
                { p => p.ClientType }).SingleOrDefaultAsync();

        }

        public IReadOnlyList<Client> GetClientsByAddress(string address)
        {
            var clientInCity = _context.Clients.Join(
                    _context.Addresses,
                    c => c.Id,
                    a => a.ClientId,
                    (c, a) => new { Client = c, Address = a }
                )
                .Where(ca => ca.Address.City == address || ca.Address.Country == address || ca.Address.Street == address)
                .Select(ca => ca.Client)
                .ToList();
            return clientInCity;
        }

        public void CreateClient(Client client) => CreateAsync(client);

        public void DeleteClient(Client client) => Delete(client);

        public void UpdateClient(Client client) => Update(client);

        public async Task<Client> GetClientSpecById(ISpecification<Client> spec)
        {
            return await ApplySpecification(spec).FirstOrDefaultAsync();
        }

        public async Task<IReadOnlyList<Client>> GetAllClientSpec(ISpecification<Client> spec)
        {
            return await ApplySpecification(spec).ToListAsync();
        }

        private IQueryable<Client> ApplySpecification(ISpecification<Client> spec)
        {
            return SpecificationEvaluator<Client>.GetQuery(_context.Set<Client>(), spec);
        }
    }
}
