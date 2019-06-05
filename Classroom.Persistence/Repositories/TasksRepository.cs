using Classroom.Common.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Classroom.Persistence.Repositories
{
    public class TasksRepository : BaseRepository
    {
        public async Task<List<TaskModel>> GetAllAsync(Guid courseId, CancellationToken cancellationToken)
        {
            var sql =
                @"
                SELECT [Id], [Name], [Description], t.[Modified], t.[Created]
                FROM [dbo].[Tasks] t
                WHERE CourseId = @CourseId";

            var param = new { CourseId = courseId };

            var definition = new CommandDefinition(sql, param, transaction: transaction, cancellationToken: cancellationToken);

            var model = await connection.QueryAsync<TaskModel>(definition);
            return model.ToList();
        }

        public async Task<int> InsertAsync(TaskModel model, CancellationToken cancellationToken)
        {
            var sql = @"INSERT INTO [dbo].[Tasks] ([Id], [Name], [Description], [Modified], [Created], [CourseId])
                VALUES (@Id, @Name, @Description, @Modified, @Created, @CourseId)";
            var param = new
            {
                model.Id,
                model.Name,
                model.Description,
                Modified = model.Modified.Value,
                model.Created,
                model.CourseId
            };

            var definition = new CommandDefinition(sql, param, transaction, cancellationToken: cancellationToken);

            return await connection.ExecuteAsync(definition);
        }

        public async Task<int> UpdateAsync(TaskModel model, CancellationToken cancellationToken)
        {
            var sql = @"UPDATE [dbo].[Tasks]
                SET [Name] = @Name,
                [Description] = @Description,
                [Modified] = @Modified
                WHERE [Id] = @Id";
            var param = new
            {
                model.Id,
                model.Name,
                model.Description,
                Modified = model.Modified.Value
            };

            var definition = new CommandDefinition(sql, param, transaction, cancellationToken: cancellationToken);

            return await connection.ExecuteAsync(definition);
        }

        public async Task<int> DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var sql = "DELETE FROM [dbo].[Tasks] WHERE [Id] = @Id";
            var param = new { Id = id };

            var definition = new CommandDefinition(sql, param, transaction, cancellationToken: cancellationToken);

            return await connection.ExecuteAsync(definition);
        }
    }
}