using System;

namespace Classroom.Common.Models.Persistence
{
    public class ClassCourseModel
    {
        public Guid ClassId { get; set; }
        public Guid CourseId { get; set; }
        public DateTime ModifiedUTC { get; set; }
        public DateTime CreatedUTC { get; set; }
    }
}