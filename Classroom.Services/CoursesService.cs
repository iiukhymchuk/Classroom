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
    public interface ICoursesService
    {
        Task<List<Course>> GetAllCoursesAsync(CancellationToken cancellationToken);
        Task<Course> GetCourseByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<Course> AddCourseAsync(Course model, CancellationToken cancellationToken);
        Task<bool> UpdateCourseAsync(Guid id, Course model, CancellationToken cancellationToken);
        Task<bool> DeleteCourseAsync(Guid id, CancellationToken cancellationToken);
    }

    public class CoursesService : ICoursesService
    {
        public async Task<List<Course>> GetAllCoursesAsync(CancellationToken cancellationToken)
        {
            return await Database.RunWithTransaction<CoursesRepository, List<Course>>(Functor);

            async Task<List<Course>> Functor(CoursesRepository repository)
            {
                var result = await repository.GetAllAsync(cancellationToken);
                return result.ToList();
            }
        }

        public async Task<Course> GetCourseByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await Database.RunWithTransaction<CoursesRepository, ClassesRepository, Course>(Functor);

            async Task<Course> Functor(CoursesRepository courses, ClassesRepository classes)
            {
                var courseTask = courses.GetByIdAsync(id, cancellationToken);
                var classesTask = classes.GetAllAsync(id, cancellationToken);

                await Task.WhenAll(courseTask, classesTask);

                var result = courseTask.Result;
                result.Classes = classesTask.Result;

                return result;
            }
        }

        public async Task<Course> AddCourseAsync(Course model, CancellationToken cancellationToken)
        {
            return await Database.RunWithTransaction<CoursesRepository, Course>(Functor);

            async Task<Course> Functor(CoursesRepository repository)
            {
                var now = DateTime.UtcNow;
                model = new Course
                {
                    Id = Guid.NewGuid(),
                    Name = model.Name,
                    Description = model.Description,
                    Modified = now,
                    Created = now
                };

                await repository.InsertAsync(model, cancellationToken);
                return model;
            }
        }

        public async Task<bool> UpdateCourseAsync(Guid id, Course model, CancellationToken cancellationToken)
        {
            return await Database.RunWithTransaction<CoursesRepository, bool>(Functor);

            async Task<bool> Functor(CoursesRepository repository)
            {
                model.Modified = DateTime.UtcNow;
                var affected = await repository.UpdateAsync(id, model, cancellationToken);
                return affected >= 1 ? true : false;
            }
        }

        public async Task<bool> DeleteCourseAsync(Guid id, CancellationToken cancellationToken)
        {
            return await Database.RunWithTransaction<CoursesRepository, bool>(Functor);

            async Task<bool> Functor(CoursesRepository repository)
            {
                var affected = await repository.DeleteAsync(id, cancellationToken);
                return affected >= 1 ? true : false;
            }
        }
    }
}