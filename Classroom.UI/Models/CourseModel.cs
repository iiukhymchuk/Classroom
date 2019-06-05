using Classroom.Common.Models;
using Classroom.UI.Common;
using Classroom.UI.Contracts;

namespace Classroom.UI.Models
{
    public class CourseModel : Course, INavigationItem
    {
        public string NavigationLink => LinkBuilder.BuildLinkWithIdParam(RouteConstants.Course, Id);
    }
}