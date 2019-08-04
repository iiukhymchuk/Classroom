using Microsoft.Extensions.DependencyInjection;

namespace Classroom.Persistence
{
    public static class DependencyConfig
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services)
        {
            // register dependencies of dependant layers
            // Nothing to register here

            // register dependencies of this layers
            // Nothing to register here

            return services;
        }
    }
}