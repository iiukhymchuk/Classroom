using Classroom.Common.Models;
using Classroom.UI.Common;
using Classroom.UI.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Classroom.UI.Models
{
    public class CourseModel : Course, INavigationItem
    {
        public new List<ClassModel> Classes => base.Classes.ToModel();
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