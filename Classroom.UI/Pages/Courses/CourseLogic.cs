using Classroom.Common.Models;
using Classroom.UI.Common;
using Classroom.UI.Helpers;
using Classroom.UI.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
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
        protected TaskModel TaskForCreation { get; set; } = new TaskModel();

        string Uri => GetApiRequestUriWithIdParam(RequestRouteConstants.Course, Id);

        protected override async Task OnInitAsync()
        {
            Course = await GetCourse();
            DescriptionLinesNumber = GetLinesAmount(Course.Description, 200);
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

        protected async Task AddTask()
        {
            var model = new TaskModel { Name = TaskForCreation.Name, Description = TaskForCreation.Description, CourseId = Id };
            var url = GetApiRequestUri(RequestRouteConstants.Tasks);
            var response = await Http.PostJsonGetHttpResponseAsync(url, model);

            response.ExpectStatusCodeAction(HttpStatusCode.Created,
                success: () => UpdateTasks(),
                fail: () => UriHelper.NavigateTo(BuildLinkWithCodeParam(RouteConstants.Error, (int)response.StatusCode)));
        }

        void UpdateTasks()
        {
            Course.Tasks.Add(new TaskModel
            {
                Name = TaskForCreation.Name,
                Description = TaskForCreation.Description,
                CourseId = Id
            });

            Course.Tasks.OrderBy(x => x.Name).ThenBy(x => x.Description);
            TaskForCreation.Name = "";
            TaskForCreation.Description = "";
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