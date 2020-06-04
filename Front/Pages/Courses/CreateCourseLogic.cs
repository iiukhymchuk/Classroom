using Classroom.Common.Models;
using Front.Common;
using Front.Contracts;
using Front.Helpers;
using Front.Models;
using System.Threading.Tasks;

namespace Front.Pages.Courses
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