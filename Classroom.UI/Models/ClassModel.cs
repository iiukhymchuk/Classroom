using Classroom.Common.Models;
using Classroom.UI.Common;
using Classroom.UI.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Classroom.UI.Models
{
    public class ClassModel : Class, INavigationItem
    {
        public new List<CourseModel> Courses => base.Courses.ToModel();
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