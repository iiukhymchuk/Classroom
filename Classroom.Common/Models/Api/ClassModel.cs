using System;

namespace Classroom.Common.Models.Api
{
    public class ClassModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
    }
}