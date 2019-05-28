using Classroom.Common.Models.Persistence;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Classroom.Persistence.Database.Classes
{
    public sealed class ClassesRepository : BaseRepository
    {
        public async Task<List<ClassModel>> GetAllAsync(CancellationToken cancellationToken)
        {
            var sql = @"SELECT [Id], [Name], [Description], [ModifiedUTC], [CreatedUTC] FROM [dbo].[Classes]";

            var definition = new CommandDefinition(sql, transaction: transaction, cancellationToken: cancellationToken);

            var @class = await connection.QueryAsync<ClassModel>(definition);
            return @class.ToList();
        }

        public async Task<ClassModel> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var sql = @"SELECT [Id], [Name], [Description], [ModifiedUTC], [CreatedUTC] FROM [dbo].[Classes]
                WHERE Id = @Id";
            var param = new { Id = id };

            var definition = new CommandDefinition(sql, param, transaction, cancellationToken: cancellationToken);

            return await connection.QueryFirstOrDefaultAsync<ClassModel>(definition);
        }

        public async Task<int> InsertAsync(ClassModel model, CancellationToken cancellationToken)
        {
            var sql = @"INSERT INTO [dbo].[Classes] ([Id], [Name], [Description], [ModifiedUTC], [CreatedUTC])
                VALUES (@Id, @Name, @Description, @ModifiedUTC, @CreatedUTC)";
            var param = new
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                ModifiedUTC = model.ModifiedUTC,
                CreatedUTC = model.CreatedUTC
            };

            var definition = new CommandDefinition(sql, param, transaction, cancellationToken: cancellationToken);

            return await connection.ExecuteAsync(definition);
        }

        public async Task<int> UpdateAsync(Guid id, ClassInputModel model, CancellationToken cancellationToken)
        {
            var sql = @"UPDATE [dbo].[Classes]
                SET [Name] = @Name,
                [Description] = @Description,
                [ModifiedUTC] = @ModifiedUTC
                WHERE [Id] = @Id";
            var param = new
            {
                Id = id,
                Name = model.Name,
                Description = model.Description,
                ModifiedUTC = model.ModifiedUTC
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