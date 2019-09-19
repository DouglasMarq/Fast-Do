using Entidades.Entidades;
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
            //var request = CreateRequest("Login");
            var auth = new User()
            {
                Username = username,
                Password = password
            };
            var json = JsonConvert.SerializeObject(auth);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            return await _httpClient.PostAsync(API.LoginApi, content).ConfigureAwait(false);
        }

        public static async Task<HttpResponseMessage> Register(string username, string password, string email)
        {
            //var request = CreateRequest("Register");
            var register = new User()
            {
                Username = username,
                Password = password,
                Email = email
            };
            var json = JsonConvert.SerializeObject(register);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            return await _httpClient.PostAsync(API.RegisterApi, content).ConfigureAwait(false);
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
