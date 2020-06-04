using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Front.Helpers
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

        public static async Task<T> PostJsonAsync<T>(this HttpClient httpClient, string requestUri, object content)
        {
            var response = await httpClient.SendJsonGetHttpResponseAsync(HttpMethod.Post, requestUri, content);
            var result = response.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<T>(result);
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