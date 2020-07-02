using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FeatureManagementExtensions
{
    public interface IFeatureChecker<T>
    {
        Task<bool> CheckAsync(Expression<Func<T, bool>> checkExpression);
    }
}
