using Classroom.Common.Models.Api;
using Classroom.UI.Common;
using Classroom.UI.Helpers;
using Classroom.UI.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Classroom.UI.Pages.ClassPage
{
    public class ClassLogic : AppLogicComponentBase
    {
        [Parameter] protected Guid Id { get; set; }

        protected Class Class { get; set; }

        string Uri => GetApiRequestUriWithIdParam(RequestRouteConstants.Class, Id);

        protected override async Task OnParametersSetAsync()
        {
            Class = await GetClass();
        }

        async Task<Class> GetClass()
        {
            return await Http.GetJsonAsync<Class>(Uri);
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
            var model = new ClassInputModel { Description = Class.Description, Name = Class.Name };
            var response = await Http.PutJsonGetHttpResponseAsync(Uri, model);

            response.ExpectStatusCodeAction(HttpStatusCode.NoContent,
                success: () => UriHelper.NavigateTo(RouteConstants.Classes),
                fail: () => UriHelper.NavigateTo(BuildLinkWithCodeParam(RouteConstants.Error, (int)response.StatusCode)));
        }

        // Http.CancelPendingRequests
    }
}