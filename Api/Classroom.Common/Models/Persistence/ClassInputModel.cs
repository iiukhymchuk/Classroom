using System;

namespace Classroom.Common.Models.Persistence
{
    public class ClassInputModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime ModifiedUTC { get; set; }
    }
}