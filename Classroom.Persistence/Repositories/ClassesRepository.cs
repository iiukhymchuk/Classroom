using Classroom.Common.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Classroom.Persistence.Repositories
{
    public sealed class ClassesRepository : BaseRepository
    {
        public async Task<List<Class>> GetAllAsync(CancellationToken cancellationToken)
        {
            var sql = @"SELECT [Id], [Name], [Description], [Modified], [Created] FROM [dbo].[Classes]";

            var definition = new CommandDefinition(sql, transaction: transaction, cancellationToken: cancellationToken);

            var @class = await connection.QueryAsync<Class>(definition);
            return @class.ToList();
        }

        public async Task<List<Class>> GetAllAsync(Guid courseId, CancellationToken cancellationToken)
        {
            var sql =
                @"SELECT [Id], [Name], [Description], [Modified], [Created]
                FROM [dbo].[Classes]
                JOIN [ClassesCourses] cc ON c.Id = cc.ClassId";

            var definition = new CommandDefinition(sql, transaction: transaction, cancellationToken: cancellationToken);

            var @class = await connection.QueryAsync<Class>(definition);
            return @class.ToList();
        }

        public async Task<Class> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var sql = @"SELECT [Id], [Name], [Description], [Modified], [Created] FROM [dbo].[Classes]
                WHERE Id = @Id";
            var param = new { Id = id };

            var definition = new CommandDefinition(sql, param, transaction, cancellationToken: cancellationToken);

            return await connection.QueryFirstOrDefaultAsync<Class>(definition);
        }

        public async Task<int> InsertAsync(Class model, CancellationToken cancellationToken)
        {
            var sql = @"INSERT INTO [dbo].[Classes] ([Id], [Name], [Description], [Modified], [Created])
                VALUES (@Id, @Name, @Description, @Modified, @Created)";
            var param = new
            {
                model.Id,
                model.Name,
                model.Description,
                model.Modified.Value,
                model.Created
            };

            var definition = new CommandDefinition(sql, param, transaction, cancellationToken: cancellationToken);

            return await connection.ExecuteAsync(definition);
        }

        public async Task<int> UpdateAsync(Guid id, Class model, CancellationToken cancellationToken)
        {
            var sql = @"UPDATE [dbo].[Classes]
                SET [Name] = @Name,
                [Description] = @Description,
                [Modified] = @Modified
                WHERE [Id] = @Id";
            var param = new
            {
                Id = id,
                model.Name,
                model.Description,
                model.Modified.Value
            };

            var definition = new CommandDefinition(sql, param, transaction, cancellationToken: cancellationToken);

            return await connection.ExecuteAsync(definition);
        }

        public async Task<int> DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var sql = "DELETE FROM [dbo].[Classes] WHERE [Id] = @Id";
            var param = new { Id = id };

            var definition = new CommandDefinition(sql, param, transaction, cancellationToken: cancellationToken);

            return await connection.ExecuteAsync(definition);
        }
    }
}