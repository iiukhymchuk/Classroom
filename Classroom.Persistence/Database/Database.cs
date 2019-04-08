using Classroom.Persistence.Contracts;
using System;
using System.Threading.Tasks;

namespace Classroom.Persistence.Database
{
    public static class Database
    {
        public static async Task<TResult> RunWithTransaction<TResult>(Func<IUnitOfWork, Task<TResult>> func)
        {
            using (var session = new DatabaseSession())
            {
                IUnitOfWork uow = session.UnitOfWork;
                uow.Begin();
                try
                {
                    var result = await func?.Invoke(uow);

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

        public static async Task RunWithTransaction(Func<IUnitOfWork, Task> action)
        {
            using (var session = new DatabaseSession())
            {
                IUnitOfWork uow = session.UnitOfWork;
                uow.Begin();
                try
                {
                    await action?.Invoke(uow);

                    uow.Commit();
                }
                catch
                {
                    uow.Rollback();
                    throw;
                }
            }
        }
    }
}