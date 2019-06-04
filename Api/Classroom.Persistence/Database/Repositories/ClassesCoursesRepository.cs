using Classroom.Common.Models.Persistence;
using Dapper;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Classroom.Persistence.Database.Repositories
{
    class ClassesCoursesRepository : BaseRepository
    {
        public async Task<int> InsertAsync(ClassCourseModel model, CancellationToken cancellationToken)
        {
            var sql = @"INSERT INTO [dbo].[ClassesCourses] ([ClassId], [CourseId], [ModifiedUTC], [CreatedUTC])
                VALUES (@ClassId, @CourseId, @ModifiedUTC, @CreatedUTC)";
            var param = new
            {
                model.ClassId,
                model.CourseId,
                model.ModifiedUTC,
                model.CreatedUTC
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