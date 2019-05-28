using Classroom.Common.Models.Api;
using Classroom.UI.Common;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace Classroom.UI.Pages.Classes
{
    public abstract class ClassesLogic : AppLogicComponentBase
    {
        protected ClassModel[] Classes { get; set; }

        protected override async Task OnInitAsync()
        {
            var url = GetRequestUri(RequestRouteConstants.Classes);
            Classes = await Http.GetJsonAsync<ClassModel[]>(url);
        }
    }
}