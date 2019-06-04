using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Classroom.UI.Helpers
{
    public static class HttpClientHelpers
    {
        public static async Task<HttpResponseMessage> PutJsonGetHttpResponseAsync(this HttpClient httpClient,
            string requestUri, object content)
        {
            return await httpClient.SendJsonGetHttpResponseAsync(HttpMethod.Put, requestUri, content);
        }

        public static async Task<HttpResponseMessage> PostJsonGetHttpResponseAsync(this HttpClient httpClient,
            string requestUri, object content)
        {
            return await httpClient.SendJsonGetHttpResponseAsync(HttpMethod.Post, requestUri, content);
        }

        static async Task<HttpResponseMessage> SendJsonGetHttpResponseAsync(this HttpClient httpClient,
            HttpMethod method, string requestUri, object content)
        {
            var requestJson = JsonConvert.SerializeObject(content);
            return await httpClient.SendAsync(new HttpRequestMessage(method, requestUri)
            {
                Content = new StringContent(requestJson, Encoding.UTF8, "application/json")
            });
        }
    }
}