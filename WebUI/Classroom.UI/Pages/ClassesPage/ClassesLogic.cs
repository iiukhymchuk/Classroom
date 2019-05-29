using Classroom.UI.Common;
using Classroom.UI.Models;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;


namespace Classroom.UI.Pages.ClassesPage
{
    public abstract class ClassesLogic : AppLogicComponentBase
    {
        [Inject] protected IUriHelper UriHelper { get; set; }

        protected Class[] Classes { get; set; }

        protected override async Task OnInitAsync()
        {
            var url = GetApiRequestUri(RequestRouteConstants.Classes);
            Classes = await Http.GetJsonAsync<Class[]>(url);
        }
    }
}