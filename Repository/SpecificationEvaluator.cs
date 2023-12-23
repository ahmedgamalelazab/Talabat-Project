using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public static class SpecificationEvaluator<TEntity> where TEntity : BaseEntity
    {
        /// <summary>
        /// inputQuery => _context.Set<TEntity>
        /// spec => Criteria and Includes
        /// </summary>
        /// <param name="inputQuery"></param>
        /// <param name="spec"></param>
        /// <returns></returns>
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery, ISpecification<TEntity> spec)
        {
            var query = inputQuery; //_context.Set<TEntity>
            if (spec.Criteria != null)
                query = query.Where(spec.Criteria);
            // _Context.Set<product>().Where(p => p.Id == 10)
            query = spec.Includes.Aggregate(query, (currentQuery, includeExperssion) => currentQuery.Include(includeExperssion));
            // _Context.Set<product>().Where(p => p.Id == 10).Include(p => p.ProductBrand)
            // _Context.Set<product>().Where(p => p.Id == 10).Include(p => p.ProductBrand).Include(p => p.ProductType)

            return query;
        }
    }
}
