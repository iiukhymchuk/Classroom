using Classroom.UI.Common.Components;
using Classroom.UI.Contracts;
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
        [Inject] protected IUriHelper UriHelper { get; set; }

        protected string GetApiRequestUri(string path)
        {
            return new UriBuilder($"{RequestRouteConstants.ApiPath.Trim('/', '\\')}/{LinkBuilder.NormalizePath(path)}").ToString();
        }

        protected string GetApiRequestUriWithIdParam(string path, Guid id)
        {
            var parsed = LinkBuilder.BuildPath(path, new UriParameter { Name = "Id", Value = id });
            return GetApiRequestUri(parsed);
        }

        protected string BuildLinkWithParam(string path, UriParameter param)
        {
            var parsed = LinkBuilder.BuildPath(path, param);
            return LinkBuilder.BuildLink(parsed);
        }

        protected string BuildLinkWithIdParam(string path, Guid id)
        {
            var parsed = LinkBuilder.BuildPath(path, new UriParameter { Name = "Id", Value = id });
            return LinkBuilder.BuildLink(parsed);
        }

        protected string BuildLinkWithCodeParam(string path, int code)
        {
            var parsed = LinkBuilder.BuildPath(path, new UriParameter { Name = "Code", Value = code });
            return LinkBuilder.BuildLink(parsed);
        }

        protected int GetLinesAmount(string description, int width)
        {
            var lines = description.Split('\n');
            var linesNumber = lines.Length;

            foreach (var line in lines)
            {
                if (line.Length > width)
                {
                    linesNumber += line.Length / width;
                }
            }

            return linesNumber;
        }
    }
}