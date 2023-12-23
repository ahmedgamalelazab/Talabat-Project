using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Security.AccessControl;

namespace Repository
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : BaseEntity
    {
        private readonly RepositoryContext _context;

        public RepositoryBase(RepositoryContext context)
        {
            _context=context;
        }
        public IQueryable<T> FindAllWithListOfExpression
            (bool trackChanges, List<Expression<Func<T, object>>> Includes = null)
        {
            var queryable = !trackChanges ? _context.Set<T>().AsNoTracking() : _context.Set<T>();
            if (Includes != null)
            {
                queryable= Includes.Aggregate(queryable, (current, include) =>
                current.Include(include));
            }
            return queryable;
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges,
             List<Expression<Func<T, object>>> Includes = null)
        {
            var queryalbe = !trackChanges ? _context.Set<T>().Where(expression).AsNoTracking() : _context.Set<T>().Where(expression);
            if (Includes != null)
            {
                queryalbe = Includes.Aggregate(queryalbe, (current, include) => current.Include(include));
            }
            return queryalbe;
        }

        public async Task CreateAsync(T entity) => await _context.Set<T>().AddAsync(entity);

        public void Delete(T entity) => _context.Set<T>().Remove(entity);

        public void Update(T entity)
            => _context.Set<T>().Update(entity);
            //=> _context.Entry(entity).State = EntityState.Modified;  ///this update every thing not updated and updated

        public IQueryable<T> FindAll(bool trackChanges)
            => !trackChanges ? _context.Set<T>().AsNoTracking() : _context.Set<T>();

        public async Task<T> FindById(Expression<Func<T, bool>> expression, bool trackChanges)
            => !trackChanges ? await _context.Set<T>().Where(expression).AsNoTracking().SingleOrDefaultAsync() : await _context.Set<T>().Where(expression).SingleOrDefaultAsync();

        public async Task<T> GetByIdAsync(int id)
        {   
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task Save()
            => await _context.SaveChangesAsync();
        
    }   
}
