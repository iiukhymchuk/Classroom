using Classroom.Common.Models.Api;
using Classroom.UI.Common;
using Classroom.UI.Contracts;
using Classroom.UI.Models;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace Classroom.UI.Pages.ClassPage
{
    public abstract class CreateClassLogic : AppLogicComponentBase
    {
        protected ClassInputModel Class { get; set; } = new ClassInputModel();

        string RequestUri => GetApiRequestUri(RequestRouteConstants.Classes);

        protected async Task CreateClass()
        {
            var model = new ClassInputModel { Description = Class.Description, Name = Class.Name };
            var @class = await Http.PostJsonAsync<Class>(RequestUri, model);

            UriHelper.NavigateTo(((INavigationItem) @class).NavigationLink);
        }

        protected void KeyPressed(UIKeyboardEventArgs args)
        {
        }
    }
}