using Classroom.UI.Common;
using Classroom.UI.Models;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace Classroom.UI.Pages.Courses
{
    public class CoursesLogic : AppLogicComponentBase
    {
        protected CourseModel[] Courses { get; set; }

        protected override async Task OnInitAsync()
        {
            var url = GetApiRequestUri(RequestRouteConstants.Courses);
            Courses = await Http.GetJsonAsync<CourseModel[]>(url);
        }
    }
}
