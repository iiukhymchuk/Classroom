using Classroom.Common.Models.Persistence;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Classroom.Persistence.Database.Repositories
{
    public sealed class CoursesRepository : BaseRepository
    {
        public async Task<List<CourseModel>> GetAllAsync(CancellationToken cancellationToken)
        {
            var sql = @"SELECT [Id], [Name], [Description], [ModifiedUTC], [CreatedUTC] FROM [dbo].[Courses]";

            var definition = new CommandDefinition(sql, transaction: transaction, cancellationToken: cancellationToken);

            var @class = await connection.QueryAsync<CourseModel>(definition);
            return @class.ToList();
        }

        public async Task<CourseModel> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var sql = @"SELECT [Id], [Name], [Description], [ModifiedUTC], [CreatedUTC] FROM [dbo].[Courses]
                WHERE Id = @Id";
            var param = new { Id = id };

            var definition = new CommandDefinition(sql, param, transaction, cancellationToken: cancellationToken);

            return await connection.QueryFirstOrDefaultAsync<CourseModel>(definition);
        }

        public async Task<int> InsertAsync(CourseModel model, CancellationToken cancellationToken)
        {
            var sql = @"INSERT INTO [dbo].[Courses] ([Id], [Name], [Description], [ModifiedUTC], [CreatedUTC])
                VALUES (@Id, @Name, @Description, @ModifiedUTC, @CreatedUTC)";
            var param = new
            {
                model.Id,
                model.Name,
                model.Description,
                model.ModifiedUTC,
                model.CreatedUTC
            };

            var definition = new CommandDefinition(sql, param, transaction, cancellationToken: cancellationToken);

            return await connection.ExecuteAsync(definition);
        }

        public async Task<int> UpdateAsync(Guid id, CourseModel model, CancellationToken cancellationToken)
        {
            var sql = @"UPDATE [dbo].[Courses]
                SET [Name] = @Name,
                [Description] = @Description,
                [ModifiedUTC] = @ModifiedUTC
                WHERE [Id] = @Id";
            var param = new
            {
                Id = id,
                model.Name,
                model.Description,
                model.ModifiedUTC
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