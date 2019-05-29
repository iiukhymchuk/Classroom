using Classroom.UI.Common.Components;
using Classroom.UI.Contracts;
using Classroom.UI.Helpers;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Layouts;
using System;
using System.Net.Http;

namespace Classroom.UI.Common
{
    [Layout(typeof(MainLayout))]
    public abstract class AppLogicComponentBase: ComponentBase
    {
        [Inject] protected HttpClient Http { get; set; }

        protected string GetApiRequestUri(string path)
        {
            return new UriBuilder($"{RequestRouteConstants.ApiPath.Trim('/', '\\')}/{LinkBuilder.NormalizePath(path)}").ToString();
        }

        protected string GetApiRequestUriWithIdParam(string path, Guid id)
        {
            var parsed = LinkBuilder.BuildPath(path, new UriParameter { Name = "Id", Value = id });
            return GetApiRequestUri(parsed);
        }

        protected string BuildLinkWithIdParam(string path, Guid id)
        {
            var parsed = LinkBuilder.BuildPath(path, new UriParameter { Name = "Id", Value = id });
            return LinkBuilder.BuildLink(parsed);
        }
    }
}