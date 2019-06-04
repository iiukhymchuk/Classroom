using System.Data;
using Classroom.Persistence.Contracts;

namespace Classroom.Persistence.Repositories
{
    public class BaseRepository : IRepository
    {
        protected IDbConnection connection = null;
        protected IDbTransaction transaction = null;

        public void SetConnection(IDbConnection connection)
        {
            this.connection = connection;
        }

        public void SetTransaction(IDbTransaction transaction)
        {
            this.transaction = transaction;
        }
    }
}