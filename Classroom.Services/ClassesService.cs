using Classroom.Persistence.Database;
using Classroom.Persistence.Database.Classes;
using Classroom.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Classroom.Services
{
    public interface IClassesService
    {
        Task<List<ClassModel>> GetClassesAsync(CancellationToken cancellationToken);
        Task<ClassModel> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<int> AddClassAsync(ClassModel @class, CancellationToken cancellationToken);
    }

    public class ClassesService : IClassesService
    {
        public async Task<List<ClassModel>> GetClassesAsync(CancellationToken cancellationToken)
        {
            using (var session = new DatabaseSession())
            {
                var uow = session.UnitOfWork;
                uow.Begin();
                try
                {
                    var repository = new ClassesRepository(uow);
                    var result = await repository.GetAllAsync(cancellationToken);
                    uow.Commit();
                    return result.Select(ToClassModel).ToList();
                }
                catch
                {
                    uow.Rollback();
                    throw;
                }
            }
        }

        public async Task<ClassModel> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            using (var session = new DatabaseSession())
            {
                var uow = session.UnitOfWork;
                uow.Begin();
                try
                {
                    var repository = new ClassesRepository(uow);
                    var result = await repository.GetByIdAsync(id, cancellationToken);
                    uow.Commit();
                    return ToClassModel(result);
                }
                catch
                {
                    uow.Rollback();
                    throw;
                }
            }
        }

        public async Task<int> AddClassAsync(ClassModel classModel, CancellationToken cancellationToken)
        {
            using (var session = new DatabaseSession())
            {
                var uow = session.UnitOfWork;
                uow.Begin();
                try
                {
                    var repository = new ClassesRepository(uow);
                    var result = await repository.InsertAsync(ToClass(classModel), cancellationToken);

                    uow.Commit();
                    return result;
                }
                catch
                {
                    uow.Rollback();
                    throw;
                }
            }
        }

        private ClassModel ToClassModel(Class @class)
        {
            return new ClassModel
            {
                Id = @class.Id,
                Name = @class.Name,
                Description = @class.Description,
                ModifiedUTC = @class.ModifiedUTC,
                CreatedUTC = @class.CreatedUTC
            };
        }

        private Class ToClass(ClassModel classModel)
        {
            return new Class
            {
                Id = classModel.Id,
                Name = classModel.Name,
                Description = classModel.Description,
                ModifiedUTC = classModel.ModifiedUTC,
                CreatedUTC = classModel.CreatedUTC
            };
        }
    }
}