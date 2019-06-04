using Classroom.Common.Models;
using Classroom.UI.Common;
using Classroom.UI.Contracts;

namespace Classroom.UI.Models
{
    public class ClassModel : Class, INavigationItem
    {
        public string NavigationLink => LinkBuilder.BuildLinkWithIdParam(RouteConstants.Class, Id);
    }
}