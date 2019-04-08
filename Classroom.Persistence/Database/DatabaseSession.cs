using Classroom.Persistence.Contracts;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Classroom.Persistence.Database
{
    public sealed class DatabaseSession : IDisposable
    {
        IDbConnection connection = null;
        IUnitOfWork unitOfWork = null;

        public DatabaseSession()
        {
            connection = new SqlConnection(DatabaseCommon.ConnectionString);
            connection.Open();
            unitOfWork = new UnitOfWork(connection);
        }

        public IUnitOfWork UnitOfWork
        {
            get { return unitOfWork; }
        }

        public void Dispose()
        {
            unitOfWork.Dispose();
            connection.Dispose();
        }
    }
}