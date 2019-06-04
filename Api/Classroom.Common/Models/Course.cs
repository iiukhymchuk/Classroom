using System;
using System.Collections.Generic;

namespace Classroom.Common.Models
{
    public class Course
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? Modified{ get; set; }
        public DateTime Created { get; set; }
        public List<Class> Classes { get; set; }
    }
}