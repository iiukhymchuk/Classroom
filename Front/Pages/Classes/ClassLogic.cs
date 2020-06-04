using Classroom.Common.Models;
using Front.Common;
using Front.Helpers;
using Front.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Front.Pages.Classes
{
    public abstract class ClassLogic : AppLogicComponentBase
    {
        [Parameter] public Guid Id { get; set; }

        protected bool IsNameDisabled { get; set; } = true;
        protected bool IsDescriptionDisabled { get; set; } = true;
        protected bool ShowEditButton { get; set; } = false;
        protected int DescriptionLinesNumber { get; set; } = 3;

        protected enum Property { Name, Description }

        protected ClassModel Class { get; set; }

        string Uri => GetApiRequestUriWithIdParam(RequestRouteConstants.Class, Id);

        protected override async Task OnInitializedAsync()
        {
            Class = await GetClass();
            DescriptionLinesNumber = GetLinesAmount(Class.Description, 200);
        }

        async Task<ClassModel> GetClass()
        {
            return await Http.GetFromJsonAsync<ClassModel>(Uri);
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

        protected void SetEnabled(MouseEventArgs args, Property property)
        {
            if (args.Detail == 2)
                SetState(property, false);
        }

        protected void SetDisabled(FocusEventArgs args, Property property)
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