﻿using Microsoft.Extensions.DependencyInjection;

namespace Classroom.Api.AppStart
{
    public static class DependencyConfig
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services)
        {
            // register dependencies of dependant layers
            Services.DependencyConfig.AddDependencies(services);

            return services;
        }
    }
}