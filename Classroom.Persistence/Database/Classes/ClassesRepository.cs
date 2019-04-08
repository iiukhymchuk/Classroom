using Classroom.Persistence.Contracts;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Classroom.Persistence.Database.Classes
{
    public sealed class ClassesRepository
    {
        readonly IDbConnection connection = null;
        readonly IDbTransaction transaction = null;

        public ClassesRepository(IUnitOfWork unitOfWork)
        {
            transaction = unitOfWork.Transaction;
            connection = unitOfWork.Connection;
        }

        public async Task<List<Class>> GetAllAsync(CancellationToken cancellationToken)
        {
            var sql = @"SELECT [Id], [Name], [Description], [ModifiedUTC], [CreatedUTC] FROM [dbo].[Classes]";

            var commandDefinition = new CommandDefinition(sql, transaction: transaction, cancellationToken: cancellationToken);

            var @class = await connection.QueryAsync<Class>(commandDefinition);
            return @class.ToList();
        }

        public async Task<Class> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var sql = @"SELECT [Id], [Name], [Description], [ModifiedUTC], [CreatedUTC] FROM [dbo].[Classes]
                WHERE Id = @Id";
            var param = new { Id = id };

            var commandDefinition = new CommandDefinition(sql, param, transaction, cancellationToken: cancellationToken);

            return await connection.QueryFirstOrDefaultAsync<Class>(commandDefinition);
        }

        public async Task<int> InsertAsync(Class @class, CancellationToken cancellationToken)
        {
            var sql = @"INSERT INTO [dbo].[Classes] ([Id], [Name], [Description], [ModifiedUTC], [CreatedUTC])
                VALUES (@Id, @Name, @Description, @ModifiedUTC, @CreatedUTC)";
            var param = new
            {
                Id = @class.Id,
                Name = @class.Name,
                Description = @class.Description,
                ModifiedUTC = @class.ModifiedUTC,
                CreatedUTC = @class.CreatedUTC
            };

            var commandDefinition = new CommandDefinition(sql, param, transaction, cancellationToken: cancellationToken);

            return await connection.ExecuteAsync(commandDefinition);
        }
    }
}