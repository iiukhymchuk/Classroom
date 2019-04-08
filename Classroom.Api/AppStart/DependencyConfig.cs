﻿using Classroom.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Classroom.Api.AppStart
{
    public static class DependencyConfig
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services)
        {
            services.AddTransient<IClassesService, ClassesService>();
            return services;
        }
    }
}