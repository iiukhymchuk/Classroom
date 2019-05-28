using Classroom.UI.Common.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Layouts;
using System;
using System.Net.Http;

namespace Classroom.UI.Common
{
    [Layout(typeof(MainLayout))]
    public abstract class AppLogicComponentBase: ComponentBase
    {
        [Inject]
        protected HttpClient Http { get; set; }

        protected string GetRequestUri(string path)
        {
            return new UriBuilder($"{RequestRouteConstants.ApiPath.Trim('/', '\\')}/{path.Trim('/', '\\')}").ToString();
        }
    }
}