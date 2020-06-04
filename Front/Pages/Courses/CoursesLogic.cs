using Front.Common;
using Front.Models;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Front.Pages.Courses
{
    public class CoursesLogic : AppLogicComponentBase
    {
        protected CourseModel[] Courses { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var url = GetApiRequestUri(RequestRouteConstants.Courses);
            Courses = await Http.GetFromJsonAsync<CourseModel[]>(url);
        }
    }
}
