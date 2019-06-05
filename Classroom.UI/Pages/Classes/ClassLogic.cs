using Classroom.Common.Models;
using Classroom.UI.Common;
using Classroom.UI.Helpers;
using Classroom.UI.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Classroom.UI.Pages.Classes
{
    public abstract class ClassLogic : AppLogicComponentBase
    {
        [Parameter] protected Guid Id { get; set; }

        protected bool IsNameDisabled { get; set; } = true;
        protected bool IsDescriptionDisabled { get; set; } = true;
        protected bool ShowEditButton { get; set; } = false;
        protected int DescriptionLinesNumber { get; set; } = 3;

        protected enum Property { Name, Description }

        protected ClassModel Class { get; set; }

        string Uri => GetApiRequestUriWithIdParam(RequestRouteConstants.Class, Id);

        protected override async Task OnInitAsync()
        {
            Class = await GetClass();
            DescriptionLinesNumber = Class.Description.Split('\n').Length;
        }

        async Task<ClassModel> GetClass()
        {
            return await Http.GetJsonAsync<ClassModel>(Uri);
        }

        protected async Task DeleteClass()
        {
            var response = await Http.DeleteAsync(Uri);

            response.ExpectStatusCodeAction(HttpStatusCode.NoContent,
                success: () => UriHelper.NavigateTo(RouteConstants.Classes),
                fail: () => UriHelper.NavigateTo(BuildLinkWithCodeParam(RouteConstants.Error, (int)response.StatusCode)));
        }

        protected async Task EditClass()
        {
            var model = new Class { Description = Class.Description, Name = Class.Name };
            var response = await Http.PutJsonGetHttpResponseAsync(Uri, model);

            response.ExpectStatusCodeAction(HttpStatusCode.NoContent,
                success: () => UriHelper.NavigateTo(RouteConstants.Classes),
                fail: () => UriHelper.NavigateTo(BuildLinkWithCodeParam(RouteConstants.Error, (int)response.StatusCode)));
        }

        protected void SetEditButtonVisible()
        {
            ShowEditButton = true;
        }

        protected void SetEnabled(UIMouseEventArgs args, Property property)
        {
            if (args.Detail == 2)
                SetState(property, false);
        }

        protected void SetDisabled(UIFocusEventArgs args, Property property)
        {
            SetState(property, true);
        }

        void SetState(Property property, bool value)
        {
            switch (property)
            {
                case Property.Name:
                    IsNameDisabled = value;
                    break;
                case Property.Description:
                    IsDescriptionDisabled = value;
                    break;
            }
        }
    }
}