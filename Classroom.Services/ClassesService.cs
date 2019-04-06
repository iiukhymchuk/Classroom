using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Classroom.Services
{
    public interface IClassesService
    {
        Task<List<Class>> GetClasses(CancellationToken cancellationToken);
    }
    public class ClassesService : IClassesService
    {
        public async Task<List<Class>> GetClasses(CancellationToken cancellationToken)
        {
            var classes = new List<Class>
            {
                new Class
                {
                    Id = new Guid("8c79aac8-9588-450c-b851-b6ae76b362ea"),
                    Name = "class 1",
                    Description = "Class about programming"
                },
                new Class
                {
                    Id = new Guid("d3ef34d9-097d-473b-95c3-e2b692019205"),
                    Name = "class 2",
                    Description = "Class about arts"
                }
            };

            return await Task.Run(() => classes);
        }
    }
}