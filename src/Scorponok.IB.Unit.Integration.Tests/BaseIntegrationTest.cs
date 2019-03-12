using System;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;

namespace Scorponok.IB.Unit.Integration.Tests
{

    public static class HttpClientExtensions
    {
        public static Task<HttpResponseMessage> DeleteAsJsonAsync<T>(this HttpClient httpClient, string requestUri, T data)
        {
            return httpClient.SendAsync(new HttpRequestMessage(HttpMethod.Delete, requestUri)
            {
                Content = Serialize(data)
            });
        }

        public static Task<HttpResponseMessage> DeleteAsJsonAsync<T>(this HttpClient httpClient, string requestUri, T data, CancellationToken cancellationToken)
            => httpClient.SendAsync(new HttpRequestMessage(HttpMethod.Delete, requestUri) { Content = Serialize(data) }, cancellationToken);

        public static Task<HttpResponseMessage> DeleteAsJsonAsync<T>(this HttpClient httpClient, Uri requestUri, T data)
            => httpClient.SendAsync(new HttpRequestMessage(HttpMethod.Delete, requestUri) { Content = Serialize(data) });

        public static Task<HttpResponseMessage> DeleteAsJsonAsync<T>(this HttpClient httpClient, Uri requestUri, T data, CancellationToken cancellationToken)
            => httpClient.SendAsync(new HttpRequestMessage(HttpMethod.Delete, requestUri) { Content = Serialize(data) }, cancellationToken);

        private static HttpContent Serialize(object data) => new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
    }

    public static class BaseIntegrationTest
    {

        private const int PortWebApi = 44312;

        public static TestServer Server { get; set; }

        private static HttpClient _httpClient => Server.CreateClient();


        public static async Task<HttpResponseMessage> PostAsync(object messageRequest, string route)
        {
            var json = JsonConvert.SerializeObject(messageRequest);

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri($"https://localhost:{PortWebApi}/api/{ route }"),
                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };

            return await _httpClient.SendAsync(request);
        }

        public static async Task<HttpResponseMessage> PutAsync(object messageRequest, string route)
        {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(messageRequest);

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Put,
                RequestUri = new Uri($"http://localhost:{PortWebApi}/api/{ route }"),
                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };

            return await _httpClient.SendAsync(request);
        }

        public static async Task<HttpResponseMessage> DeleteAsync(object messageRequest, string route)
        {
            return await _httpClient.DeleteAsJsonAsync($"http://localhost:{PortWebApi}/api/{route}", messageRequest);

            //return await _httpClient.SendAsync(request);
        }

    }
}