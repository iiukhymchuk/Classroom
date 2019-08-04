using Microsoft.Extensions.DependencyInjection;

namespace Classroom.Services
{
    public static class DependencyConfig
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services)
        {
            // register dependencies of dependant layers
            Persistence.DependencyConfig.AddDependencies(services);

            // register dependencies of this layers
            services.AddTransient<IClassesService, ClassesService>();
            services.AddTransient<ICoursesService, CoursesService>();
            services.AddTransient<ITasksService, TasksService>();

            return services;
        }
    }
}