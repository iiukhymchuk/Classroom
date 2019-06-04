using System;

namespace Classroom.Common.Models
{
    public class ClassCourse
    {
        public Guid ClassId { get; set; }
        public Guid CourseId { get; set; }
        public DateTime? Modified { get; set; }
        public DateTime Created { get; set; }
    }
}