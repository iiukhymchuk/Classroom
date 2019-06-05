using Classroom.Common.Models;
using Classroom.UI.Common;
using Classroom.UI.Contracts;
using Classroom.UI.Models;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace Classroom.UI.Pages.Courses
{
    public abstract class CreateCourseLogic : AppLogicComponentBase
    {
        protected Course Course { get; set; } = new Course();

        string RequestUri => GetApiRequestUri(RequestRouteConstants.Courses);

        protected async Task CreateCourse()
        {
            var model = new Course { Description = Course.Description, Name = Course.Name };
            var course = await Http.PostJsonAsync<CourseModel>(RequestUri, model);

            UriHelper.NavigateTo(((INavigationItem)course).NavigationLink);
        }
    }
}