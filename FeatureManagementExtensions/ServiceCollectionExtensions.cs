using Microsoft.Extensions.DependencyInjection;

namespace FeatureManagementExtensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddFeatureChecker(this IServiceCollection services)
        {
            services.AddSingleton(typeof(IFeatureChecker<>), typeof(FeatureChecker<>));
        }
    }
}
