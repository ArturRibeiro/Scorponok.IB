using System;

namespace Scorponok.IB.Cross.Cutting.Ioc
{
    public static class ServiceProviderExtension
    {
        public static T GetInstance<T>(this IServiceProvider serviceProvider)
        {
            var instance = (T)serviceProvider.GetService(typeof(T));
            return instance;
        }
    }
}