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
    public interface ITasksService
    {
        Task<List<TaskModel>> GetAllTasksAsync(Guid courseId, CancellationToken cancellationToken);
        Task<TaskModel> AddTaskAsync(TaskModel model, CancellationToken cancellationToken);
        Task<bool> UpdateTaskAsync(TaskModel model, CancellationToken cancellationToken);
        Task<bool> DeleteTaskAsync(Guid id, CancellationToken cancellationToken);
    }

    public class TasksService : ITasksService
    {
        public async Task<List<TaskModel>> GetAllTasksAsync(Guid courseId, CancellationToken cancellationToken)
        {
            return await Database.RunWithTransaction<TasksRepository, List<TaskModel>>(Functor);

            async Task<List<TaskModel>> Functor(TasksRepository repository)
            {
                var result = await repository.GetAllAsync(courseId, cancellationToken);
                return result.ToList();
            }
        }

        public async Task<TaskModel> AddTaskAsync(TaskModel model, CancellationToken cancellationToken)
        {
            return await Database.RunWithTransaction<TasksRepository, TaskModel>(Functor);

            async Task<TaskModel> Functor(TasksRepository repository)
            {
                var now = DateTime.UtcNow;

                model.Id = Guid.NewGuid();
                model.Modified = now;
                model.Created = now;

                await repository.InsertAsync(model, cancellationToken);
                return model;
            }
        }

        public async Task<bool> UpdateTaskAsync(TaskModel model, CancellationToken cancellationToken)
        {
            return await Database.RunWithTransaction<TasksRepository, bool>(Functor);

            async Task<bool> Functor(TasksRepository repository)
            {
                model.Modified = DateTime.UtcNow;
                var affected = await repository.UpdateAsync(model, cancellationToken);
                return affected >= 1 ? true : false;
            }
        }

        public async Task<bool> DeleteTaskAsync(Guid id, CancellationToken cancellationToken)
        {
            return await Database.RunWithTransaction<TasksRepository, bool>(Functor);

            async Task<bool> Functor(TasksRepository repository)
            {
                var affected = await repository.DeleteAsync(id, cancellationToken);
                return affected >= 1 ? true : false;
            }
        }
    }
}