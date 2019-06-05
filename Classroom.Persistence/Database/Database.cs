using Classroom.Persistence.Contracts;
using System;
using System.Data;
using System.Threading.Tasks;

namespace Classroom.Persistence.Database
{
    public static class Database
    {
        public static async Task<TResult> RunWithTransaction<T, TResult>(Func<T, Task<TResult>> func)
            where T : IRepository, new()
        {
            using (var session = new DatabaseSession())
            {
                IUnitOfWork uow = session.UnitOfWork;
                uow.Begin();
                try
                {
                    T repository = CreateRepository<T>(uow);
                    var result = await func?.Invoke(repository);

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

        public static async Task<TResult> RunWithTransaction<T1, T2, TResult>(Func<T1, T2, Task<TResult>> func)
            where T1 : IRepository, new()
            where T2 : IRepository, new()
        {
            using (var session = new DatabaseSession())
            {
                IUnitOfWork uow = session.UnitOfWork;
                uow.Begin();
                try
                {
                    T1 repository1 = CreateRepository<T1>(uow);
                    T2 repository2 = CreateRepository<T2>(uow);
                    var result = await func?.Invoke(repository1, repository2);

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

        public static async Task<TResult> RunWithTransaction<T1, T2, T3, TResult>(Func<T1, T2, T3, Task<TResult>> func)
            where T1 : IRepository, new()
            where T2 : IRepository, new()
            where T3 : IRepository, new()
        {
            using (var session = new DatabaseSession())
            {
                IUnitOfWork uow = session.UnitOfWork;
                uow.Begin();
                try
                {
                    T1 repository1 = CreateRepository<T1>(uow);
                    T2 repository2 = CreateRepository<T2>(uow);
                    T3 repository3 = CreateRepository<T3>(uow);
                    var result = await func?.Invoke(repository1, repository2, repository3);

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

        private static T CreateRepository<T>(IUnitOfWork uow)
            where T : IRepository, new()
        {
            var repository = new T();
            repository.SetConnection(uow.Connection);
            repository.SetTransaction(uow.Transaction);
            return repository;
        }

        private static T CreateRepository<T>(IDbConnection connection)
            where T : IRepository, new()
        {
            var repository = new T();
            repository.SetConnection(connection);
            return repository;
        }
    }
}