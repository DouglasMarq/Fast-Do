using Fast_Do.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Fast_Do.Services
{
    public static class HttpService
    {
        private static HttpClient _httpClient;

        public static void CreateHttp(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public static async Task<HttpResponseMessage> Login(string username, string password)
        {
            var auth = new User()
            {
                username = username,
                password = password
            };
            return await _httpClient.PostAsync(API.LoginApi, 
                new StringContent(JsonConvert.SerializeObject(auth), 
                Encoding.UTF8, 
                "application/json")).ConfigureAwait(false);
        }

        public static async Task<HttpResponseMessage> Register(string username, string password, string email)
        {
            var register = new User()
            {
                username = username,
                password = password,
                email = email
            };
            return await _httpClient.PostAsync(API.RegisterApi, new StringContent(JsonConvert.SerializeObject(register), 
                Encoding.UTF8, 
                "application/json")).ConfigureAwait(false);
        }

        private static HttpRequestMessage CreateRequest(string type)
        {
            switch(type)
            {
                case "Login":
                    return new HttpRequestMessage(HttpMethod.Post, API.LoginApi);
                case "Register":
                    return new HttpRequestMessage(HttpMethod.Post, API.LoginApi);
                default:
                    return null;
            }
        }
    }
}
