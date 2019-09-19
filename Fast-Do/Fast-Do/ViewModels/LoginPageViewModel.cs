using Fast_Do.Services;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Fast_Do.ViewModels
{
    public class LoginPageViewModel : BaseViewModel
    {
        private static HttpClient _httpClient;
        public async Task Login(string username, string password)
        {
            _httpClient = new HttpClient();
            HttpService.CreateHttp(_httpClient);
            var response = await HttpService.Login(username, password);
            if (response.IsSuccessStatusCode)
            {
                var content = response.Content;

                Console.WriteLine("do something");
            }
        }
    }
}
