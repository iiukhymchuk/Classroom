using Classroom.Persistence.Contracts;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Classroom.Persistence.Database
{
    public sealed class DatabaseSession : IDisposable
    {
        static readonly string connectionString =
            ConfigurationManager.ConnectionStrings["ClassroomDatabase"].ConnectionString;

        public DatabaseSession()
        {
            Connection = new SqlConnection(connectionString);
            Connection.Open();
            UnitOfWork = new UnitOfWork(Connection);
        }

        public IDbConnection Connection { get; } = null;
        public IUnitOfWork UnitOfWork { get; } = null;

        public void Dispose()
        {
            UnitOfWork?.Dispose();
            Connection?.Dispose();
        }
    }
}