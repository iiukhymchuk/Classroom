using System.Data;

namespace Classroom.Persistence.Contracts
{
    public interface IRepository
    {
        void SetConnection(IDbConnection connection);
        void SetTransaction(IDbTransaction transaction);
    }
}