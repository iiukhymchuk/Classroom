using Classroom.UI.Common;
using Classroom.UI.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace Classroom.UI.Pages.ClassPage
{
    public class ClassLogic : AppLogicComponentBase
    {
        [Parameter] protected Guid Id { get; set; }
        protected Class Class { get; set; }

        protected override async Task OnParametersSetAsync()
        {
            var url = GetApiRequestUriWithIdParam(RequestRouteConstants.Class, Id);
            Class = await Http.GetJsonAsync<Class>(url);
        }
    }
}