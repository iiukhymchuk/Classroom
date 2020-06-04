using Classroom.Common.Models;
using Front.Common;
using Front.Contracts;
using Front.Models;
using System.Collections.Generic;
using System.Linq;

namespace Front.Models
{
    public class CourseModel : Course, INavigationItem
    {
        public string NavigationLink => LinkBuilder.BuildLinkWithIdParam(RouteConstants.Course, Id);
    }

    static class CourseModelHelper
    {
        internal static List<ClassModel> ToModel(this List<Class> courses)
        {
            return courses
                .Select(x => new ClassModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    Modified = x.Modified,
                    Created = x.Created
                }).ToList();
        }
    }
}