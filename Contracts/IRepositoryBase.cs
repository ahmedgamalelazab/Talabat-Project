using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IRepositoryBase<T> where T : BaseEntity
    {
        IQueryable<T> FindAll(bool trackChanges);
        Task<T> FindById(Expression<Func<T, bool>> expression, bool trackChanges);
        IQueryable<T> FindAllWithListOfExpression
            (bool trackChanges, List<Expression<Func<T, object>>> Includes = null);
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges,
             List<Expression<Func<T, object>>> Includes = null);
        Task CreateAsync(T entity);
        void Delete(T entity);
        void Update(T entity);
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task Save();
    }
}
