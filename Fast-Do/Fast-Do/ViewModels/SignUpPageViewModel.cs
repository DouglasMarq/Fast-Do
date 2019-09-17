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
            get { return _user; }
            set { SetProperty(ref _user, value); }
        }
        #endregion

        #region Private Variables
        private string _user;
        private string _pass;
        #endregion
    }
}
