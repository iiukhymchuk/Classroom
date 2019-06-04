using Classroom.Common;
using Classroom.Common.Models.Services;
using Classroom.Persistence.Database;
using Classroom.Persistence.Database.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Classroom.Services
{
    public interface IClassesService
    {
        Task<List<ClassModel>> GetAllClassesAsync(CancellationToken cancellationToken);
        Task<ClassModel> GetClassByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<ClassModel> AddClassAsync(ClassInputModel model, CancellationToken cancellationToken);
        Task<bool> UpdateClassAsync(Guid id, ClassInputModel model, CancellationToken cancellationToken);
        Task<bool> DeleteClassAsync(Guid id, CancellationToken cancellationToken);
    }

    public class ClassesService : IClassesService
    {
        public async Task<List<ClassModel>> GetAllClassesAsync(CancellationToken cancellationToken)
        {
            return await Database.RunWithTransaction<ClassesRepository, List<ClassModel>>(Functor);

            async Task<List<ClassModel>> Functor(ClassesRepository repository)
            {
                var result = await repository.GetAllAsync(cancellationToken);
                return result.Select(x => x.ToServicesModel()).ToList();
            }
        }

        public async Task<ClassModel> GetClassByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await Database.RunWithTransaction<ClassesRepository, ClassModel>(Functor);

            async Task<ClassModel> Functor(ClassesRepository repository)
            {
                var result = await repository.GetByIdAsync(id, cancellationToken);
                return result.ToServicesModel();
            }
        }

        public async Task<ClassModel> AddClassAsync(ClassInputModel model, CancellationToken cancellationToken)
        {
            return await Database.RunWithTransaction<ClassesRepository, ClassModel>(Functor);

            async Task<ClassModel> Functor(ClassesRepository repository)
            {
                var now = DateTime.UtcNow;
                var classModel = new ClassModel
                {
                    Id = Guid.NewGuid(),
                    Name = model.Name,
                    Description = model.Description,
                    ModifiedUTC = now,
                    CreatedUTC = now
                };

                await repository.InsertAsync(classModel.ToPersistenceModel(), cancellationToken);
                return classModel;
            }
        }

        public async Task<bool> UpdateClassAsync(Guid id, ClassInputModel model, CancellationToken cancellationToken)
        {
            return await Database.RunWithTransaction<ClassesRepository, bool>(Functor);

            async Task<bool> Functor(ClassesRepository repository)
            {
                var affected = await repository.UpdateAsync(id, model.ToPersistenceModel(DateTime.UtcNow), cancellationToken);
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