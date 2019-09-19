using Fast_Do.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fast_Do.ViewModels
{
    public class SignUpPageViewModel : BaseViewModel
    {
        #region Public Variables
        public string User
        {
            get { return _user; }
            set { SetProperty(ref _user, value); }
        }
        public string Pass
        {
            get { return _pass; }
            set { SetProperty(ref _pass, value); }
        }
        public string Email
        {
            get { return _email; }
            set { SetProperty(ref _email, value); }
        }
        #endregion

        #region Private Variables
        private string _user;
        private string _pass;
        private string _email;
        #endregion

        public async void Register(string user, string pass, string email)
        {
            _user = user;
            _pass = pass;
            _email = email;
            var content = await HttpService.Register(user, pass, email);
            if (content.IsSuccessStatusCode)
            {
                var test = content.Content;
            }
        }
    }
}
