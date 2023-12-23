using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ISpecification<T> where T : BaseEntity
    {
         Expression<Func<T, bool>> Criteria { get; set; }
         List<Expression<Func<T, object>>> Includes{ get; set; }
    }
}
