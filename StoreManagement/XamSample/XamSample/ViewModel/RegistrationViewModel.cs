using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using XamSample.AppHelper;
using XamSample.Contracts;
using XamSample.Views;

namespace XamSample.ViewModel
{
    public class RegistrationViewModel
    {
        /// <summary>
        /// Gets or sets the Password.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the UserName.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the UserName.
        /// </summary>
        public string RePassword { get; set; }

        /// <summary>
        /// Gets or sets the LoginCommand.
        /// </summary>
        public ICommand SignupCommand { protected set; get; }
        private readonly ILoginService _loginService;

        public RegistrationViewModel(ILoginService loginService)
        {
            _loginService = loginService;
            SignupCommand = new Command(SignUP);
        }

        private void SignUP(object obj)
        {
            if (!string.IsNullOrEmpty(UserName) && !string.IsNullOrEmpty(Password))
            {
                if (Password == RePassword)
                {
                    bool isRegistered =_loginService.Register(UserName, Password).GetAwaiter().GetResult();
                    if (isRegistered)
                    {
                        var vm = IocContainer.Resolve<StoreMainPageViewModel>();
                        Application.Current.MainPage.Navigation.PushAsync(new StoreMainPage { BindingContext = vm });
                    }
                    else
                    {
                        // show dialog
                        Application.Current.MainPage.DisplayAlert(
                            "Registration Failed",
                            "Same user name already exists",
                            "Ok");
                    }
                }
                else
                {
                    // show dialog
                    Application.Current.MainPage.DisplayAlert(
                        "Login Failed",
                        "Password mismatched",
                        "Ok");
                }
            }
            else
            {
                // show dialog
                Application.Current.MainPage.DisplayAlert(
                    "Login Failed",
                    "user name and password is mandatory",
                    "Ok");
            }

        }
    }
}
