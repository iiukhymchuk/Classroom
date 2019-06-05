using Classroom.Common.Models;
using Classroom.Persistence.Database;
using Classroom.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Classroom.Services
{
    public interface IClassesService
    {
        Task<List<Class>> GetAllClassesAsync(CancellationToken cancellationToken);
        Task<Class> GetClassByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<Class> AddClassAsync(Class model, CancellationToken cancellationToken);
        Task<bool> UpdateClassAsync(Guid id, Class model, CancellationToken cancellationToken);
        Task<bool> DeleteClassAsync(Guid id, CancellationToken cancellationToken);
    }

    public class ClassesService : IClassesService
    {
        public async Task<List<Class>> GetAllClassesAsync(CancellationToken cancellationToken)
        {
            return await Database.RunWithTransaction<ClassesRepository, List<Class>>(Functor);

            async Task<List<Class>> Functor(ClassesRepository repository)
            {
                var result = await repository.GetAllAsync(cancellationToken);
                return result.ToList();
            }
        }

        public async Task<Class> GetClassByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await Database.RunWithTransaction<ClassesRepository, CoursesRepository, Class>(Functor);

            async Task<Class> Functor(ClassesRepository classes, CoursesRepository courses)
            {
                var classTask = classes.GetByIdAsync(id, cancellationToken);
                var coursesTask = courses.GetAllAsync(id, cancellationToken);

                await Task.WhenAll(classTask, coursesTask);

                var result = classTask.Result;
                result.Courses = coursesTask.Result.OrderBy(x => x.Name).ToList();

                return result;
            }
        }

        public async Task<Class> AddClassAsync(Class model, CancellationToken cancellationToken)
        {
            return await Database.RunWithTransaction<ClassesRepository, Class>(Functor);

            async Task<Class> Functor(ClassesRepository repository)
            {
                var now = DateTime.UtcNow;

                model.Id = Guid.NewGuid();
                model.Modified = now;
                model.Created = now;

                await repository.InsertAsync(model, cancellationToken);
                return model;
            }
        }

        public async Task<bool> UpdateClassAsync(Guid id, Class model, CancellationToken cancellationToken)
        {
            return await Database.RunWithTransaction<ClassesRepository, bool>(Functor);

            async Task<bool> Functor(ClassesRepository repository)
            {
                model.Modified = DateTime.UtcNow;
                var affected = await repository.UpdateAsync(id, model, cancellationToken);
                return affected >= 1 ? true : false;
            }
        }

        public async Task<bool> DeleteClassAsync(Guid id, CancellationToken cancellationToken)
        {
            return await Database.RunWithTransaction<ClassesRepository, bool>(Functor);

            async Task<bool> Functor(ClassesRepository repository)
            {
                var affected = await repository.DeleteAsync(id, cancellationToken);
                return affected >= 1 ? true : false;
            }
        }
    }
}