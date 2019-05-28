using Classroom.Persistence.Contracts;
using System.Data;

namespace Classroom.Persistence.Database
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        IDbConnection connection = null;
        IDbTransaction transaction = null;

        internal UnitOfWork(IDbConnection connection)
        {
            this.connection = connection;
        }

        IDbConnection IUnitOfWork.Connection
        {
            get { return connection; }
        }

        IDbTransaction IUnitOfWork.Transaction
        {
            get { return transaction; }
        }

        public void Begin()
        {
            transaction = connection.BeginTransaction();
        }

        public void Commit()
        {
            transaction.Commit();
            Dispose();
        }

        public void Rollback()
        {
            transaction.Rollback();
            Dispose();
        }

        public void Dispose()
        {
            if (transaction != null)
                transaction.Dispose();
            transaction = null;
        }
    }
}