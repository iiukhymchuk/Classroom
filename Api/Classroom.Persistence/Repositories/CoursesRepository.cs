using Classroom.Common.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Classroom.Persistence.Repositories
{
    public sealed class CoursesRepository : BaseRepository
    {
        public async Task<List<Course>> GetAllAsync(CancellationToken cancellationToken)
        {
            var sql = @"SELECT [Id], [Name], [Description], [Modified], [Created] FROM [dbo].[Courses]";

            var definition = new CommandDefinition(sql, transaction: transaction, cancellationToken: cancellationToken);

            var @class = await connection.QueryAsync<Course>(definition);
            return @class.ToList();
        }

        public async Task<List<Course>> GetAllAsync(Guid classId, CancellationToken cancellationToken)
        {
            var sql =
                @"
                SELECT [Id], [Name], [Description], [Modified], [Created]
                FROM [dbo].[Courses] c
                JOIN [ClassesCourses] cc ON c.Id = cc.CourseId";

            var definition = new CommandDefinition(sql, transaction: transaction, cancellationToken: cancellationToken);

            var @class = await connection.QueryAsync<Course>(definition);
            return @class.ToList();
        }

        public async Task<Course> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var sql = @"SELECT [Id], [Name], [Description], [Modified], [Created] FROM [dbo].[Courses]
                WHERE Id = @Id";
            var param = new { Id = id };

            var definition = new CommandDefinition(sql, param, transaction, cancellationToken: cancellationToken);

            return await connection.QueryFirstOrDefaultAsync<Course>(definition);
        }

        public async Task<int> InsertAsync(Course model, CancellationToken cancellationToken)
        {
            var sql = @"INSERT INTO [dbo].[Courses] ([Id], [Name], [Description], [Modified], [Created])
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

        public async Task<int> UpdateAsync(Guid id, Course model, CancellationToken cancellationToken)
        {
            var sql = @"UPDATE [dbo].[Courses]
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