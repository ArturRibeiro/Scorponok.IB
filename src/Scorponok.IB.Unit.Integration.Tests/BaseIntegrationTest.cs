using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.TestHost;

namespace Scorponok.IB.Unit.Integration.Tests
{
    public static class BaseIntegrationTest
    {
        private const int PortWebApi = 51052;

        public static TestServer Server { get; set; }

        private static HttpClient _httpClient => Server.CreateClient();


        public static async Task<HttpResponseMessage> PostAsync(object messageRequest, string route)
        {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(messageRequest);

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri($"http://localhost:{PortWebApi}/api/{ route }"),
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
    }
}