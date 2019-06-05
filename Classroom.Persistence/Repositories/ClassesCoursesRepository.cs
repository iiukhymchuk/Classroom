using Classroom.Common.Models;
using Dapper;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Classroom.Persistence.Repositories
{
    class ClassesCoursesRepository : BaseRepository
    {
        public async Task<int> InsertAsync(ClassCourse model, CancellationToken cancellationToken)
        {
            var sql = @"INSERT INTO [dbo].[ClassesCourses] ([ClassId], [CourseId], [Modified], [Created])
                VALUES (@ClassId, @CourseId, @Modified, @Created)";
            var param = new
            {
                model.ClassId,
                model.CourseId,
                Modified = model.Modified.Value,
                model.Created
            };

            var definition = new CommandDefinition(sql, param, transaction, cancellationToken: cancellationToken);

            return await connection.ExecuteAsync(definition);
        }

        public async Task<int> DeleteAsync(Guid classId, Guid courseId, CancellationToken cancellationToken)
        {
            var sql = "DELETE FROM [dbo].[ClassesCourses] WHERE [ClassId] = @ClassId AND [CourseId] = @CourseId";
            var param = new
            {
                ClassId = classId,
                CourseId = courseId
            };

            var definition = new CommandDefinition(sql, param, transaction, cancellationToken: cancellationToken);

            return await connection.ExecuteAsync(definition);
        }
    }
}