using System.Linq;
using Core.Entities;
using Core.Specifications;

namespace Infrastructure.Data
{
    public class SpecificationEvaluator<TEntity> where TEntity : BaseEntity
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery,
            ISpecification<TEntity> spec)
        {
            return inputQuery.Skip(spec.Skip).Take(spec.Take);;
        }
    }
}