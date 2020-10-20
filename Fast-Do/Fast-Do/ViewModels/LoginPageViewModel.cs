using Fast_Do.Models;
using Fast_Do.Services;
using Newtonsoft.Json;
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
        public async Task<bool> Login(string username, string password)
        {
            return true;
            //_httpClient = new HttpClient();
            //HttpService.CreateHttp(_httpClient);
            //var response = await HttpService.Login(username, password);
            //if (response.IsSuccessStatusCode)
            //{
            //    var content = await response.Content.ReadAsStringAsync();

            //    Login login = JsonConvert.DeserializeObject<Login>(content);

            //    var credentials = new Login()
            //    {
            //        username = username,
            //        password = password,
            //        token = login.token,
            //    };
            //    new AccessLogin().Insert(credentials);

            //    return true;
            //}
            //return false;
        }
    }
}
