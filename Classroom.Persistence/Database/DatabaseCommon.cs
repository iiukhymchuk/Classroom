using System.Configuration;

namespace Classroom.Persistence.Database
{
    static class DatabaseCommon
    {
        internal static readonly string ConnectionString =
            ConfigurationManager.ConnectionStrings["ClassroomDatabase"].ConnectionString;
    }
}