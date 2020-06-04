using Classroom.Common.Models;
using Front.Common;
using Front.Contracts;
using Front.Helpers;
using Front.Models;
using System.Threading.Tasks;

namespace Front.Pages.Classes
{
    public abstract class CreateClassLogic : AppLogicComponentBase
    {
        protected Class Class { get; set; } = new Class();

        string RequestUri => GetApiRequestUri(RequestRouteConstants.Classes);

        protected async Task CreateClass()
        {
            var model = new Class { Description = Class.Description, Name = Class.Name };
            var @class = await Http.PostJsonAsync<ClassModel>(RequestUri, model);

            UriHelper.NavigateTo(((INavigationItem)@class).NavigationLink);
        }
    }
}