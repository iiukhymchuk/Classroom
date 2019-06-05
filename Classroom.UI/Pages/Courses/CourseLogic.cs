using Classroom.Common.Models;
using Classroom.UI.Common;
using Classroom.UI.Helpers;
using Classroom.UI.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Classroom.UI.Pages.Courses
{
    public abstract class CourseLogic : AppLogicComponentBase
    {
        [Parameter] protected Guid Id { get; set; }

        protected bool IsNameDisabled { get; set; } = true;
        protected bool IsDescriptionDisabled { get; set; } = true;
        protected bool ShowEditButton { get; set; } = false;
        protected int DescriptionLinesNumber { get; set; } = 3;

        protected enum Property { Name, Description }

        protected CourseModel Course { get; set; }

        string Uri => GetApiRequestUriWithIdParam(RequestRouteConstants.Course, Id);

        protected override async Task OnInitAsync()
        {
            Course = await GetCourse();
            DescriptionLinesNumber = Course.Description.Split('\n').Length;
        }

        async Task<CourseModel> GetCourse()
        {
            return await Http.GetJsonAsync<CourseModel>(Uri);
        }

        protected async Task DeleteCourse()
        {
            var response = await Http.DeleteAsync(Uri);

            response.ExpectStatusCodeAction(HttpStatusCode.NoContent,
                success: () => UriHelper.NavigateTo(RouteConstants.Courses),
                fail: () => UriHelper.NavigateTo(BuildLinkWithCodeParam(RouteConstants.Error, (int)response.StatusCode)));
        }

        protected async Task EditCourse()
        {
            var model = new Course { Description = Course.Description, Name = Course.Name };
            var response = await Http.PutJsonGetHttpResponseAsync(Uri, model);

            response.ExpectStatusCodeAction(HttpStatusCode.NoContent,
                success: () => UriHelper.NavigateTo(RouteConstants.Courses),
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