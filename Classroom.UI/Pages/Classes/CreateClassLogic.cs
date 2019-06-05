using Classroom.Common.Models;
using Classroom.UI.Common;
using Classroom.UI.Contracts;
using Classroom.UI.Models;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace Classroom.UI.Pages.Classes
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

        protected void KeyPressed(UIKeyboardEventArgs args)
        {
        }
    }
}