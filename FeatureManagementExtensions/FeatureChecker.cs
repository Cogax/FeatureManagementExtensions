using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.FeatureManagement;

namespace FeatureManagementExtensions
{
    public class FeatureChecker<T> : IFeatureChecker<T>
    {
        private readonly IFeatureManager featureManager;

        public FeatureChecker(IFeatureManager featureManager)
        {
            this.featureManager = featureManager;
        }

        public async Task<bool> CheckAsync(Expression<Func<T, bool>> checkExpression)
        {
            return await featureManager.CheckAsync(checkExpression);
        }
    }
}
