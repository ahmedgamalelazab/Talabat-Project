using Contracts;
using Entities.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RepositoryContext _context;

        public UnitOfWork(RepositoryContext context) 
        {
            _context = context;
        }

        private Hashtable _Repository;
        public IRepositoryBase<T> Repository<T>() where T : BaseEntity
        {
            if (_Repository == null)
                _Repository = new Hashtable();
            var type = typeof(T).Name;
            if(!_Repository.Contains(type))
            {
                var repository = new RepositoryBase<T>(_context);
                _Repository.Add(type, repository);
            }
            return (IRepositoryBase<T>)_Repository[type];      
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<int> complete()
         => await _context.SaveChangesAsync();
    }
}
