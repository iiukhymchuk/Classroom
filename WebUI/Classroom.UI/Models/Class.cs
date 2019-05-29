using Classroom.Common.Models.Api;
using Classroom.UI.Common;
using Classroom.UI.Contracts;

namespace Classroom.UI.Models
{
    public class Class : ClassModel, INavigationItem
    {
        public string NavigationLink => LinkBuilder.BuildLinkWithIdParam(RouteConstants.Class, Id);
    }
}