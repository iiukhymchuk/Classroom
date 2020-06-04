using Classroom.Common.Models;
using Front.Common;
using Front.Contracts;
using Front.Models;
using System.Collections.Generic;
using System.Linq;

namespace Front.Models
{
    public class ClassModel : Class, INavigationItem
    {
        public string NavigationLink => LinkBuilder.BuildLinkWithIdParam(RouteConstants.Class, Id);
    }

    static class ClassModelHelper
    {
        internal static List<CourseModel> ToModel(this List<Course> courses)
        {
            return courses
                .Select(x => new CourseModel
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