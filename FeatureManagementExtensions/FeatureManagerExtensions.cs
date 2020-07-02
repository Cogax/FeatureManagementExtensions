using System;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.FeatureManagement;

namespace FeatureManagementExtensions
{
    public static class FeatureManagerExtensions
    {
        /// <summary>
        /// Load Feature Toggles via <see cref="IFeatureManager"/> into a Feature Flags object.
        /// </summary>
        /// <typeparam name="T">Type of the Feature Flags class</typeparam>
        /// <param name="featureManager">The Feature Manager instance</param>
        /// <returns>The Feature Flags object wrapped by a <see cref="Task"/></returns>
        public static async Task<T> LoadFeatureFlagsAsync<T>(this IFeatureManager featureManager)
        {
            var instance = (T)Activator.CreateInstance(typeof(T));

            PropertyInfo[] propertyInfo = typeof(T).GetTypeInfo().GetProperties();
            foreach (PropertyInfo p in propertyInfo)
            {
                p.SetValue(instance, await featureManager.IsEnabledAsync(p.Name));
            }

            return instance;
        }

        /// <summary>
        /// Check for typed Feature Toggles.
        /// </summary>
        /// <typeparam name="T">Type of the Feature Flags class</typeparam>
        /// <param name="featureManager">The Feature Manager instance</param>
        /// <param name="checkExpression"></param>
        /// <returns>The Feature Flags object wrapped by a <see cref="Task"/></returns>
        public static async Task<bool> CheckAsync<T>(this IFeatureManager featureManager, Expression<Func<T, bool>> checkExpression)
        {
            var features = await featureManager.LoadFeatureFlagsAsync<T>();
            return checkExpression.Compile().Invoke(features);
        }
    }
}
