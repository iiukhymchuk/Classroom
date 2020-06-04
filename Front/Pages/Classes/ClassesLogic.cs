using Front.Common;
using Front.Models;
using System.Net.Http.Json;
using System.Threading.Tasks;


namespace Front.Pages.Classes
{
    public abstract class ClassesLogic : AppLogicComponentBase
    {
        protected ClassModel[] Classes { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var url = GetApiRequestUri(RequestRouteConstants.Classes);
            Classes = await Http.GetFromJsonAsync<ClassModel[]>(url);
        }
    }
}