using System;
using System.Net;
using System.Net.Http;

namespace Classroom.UI.Helpers
{
    public static class HttpResponseHelpers
    {
        public static void ExpectStatusCodeAction(this HttpResponseMessage response,
            HttpStatusCode expectedCode, Action success, Action fail)
        {
            if (response.StatusCode == expectedCode)
                success();
            else
                fail();
        }
    }
}
