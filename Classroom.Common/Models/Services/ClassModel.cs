using System;

namespace Classroom.Common.Models.Services
{
    public class ClassModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime ModifiedUTC { get; set; }
        public DateTime CreatedUTC { get; set; }
    }
}