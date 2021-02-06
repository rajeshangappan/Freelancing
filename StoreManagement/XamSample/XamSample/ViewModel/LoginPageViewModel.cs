﻿using System.Windows.Input;
using Xamarin.Forms;
using XamSample.AppHelper;
using XamSample.Contracts;
using XamSample.Views;

namespace XamSample.ViewModel
{
    /// <summary>
    /// Defines the <see cref="LoginPageViewModel" />.
    /// </summary>
    public class LoginPageViewModel : ViewModelBase
    {
        #region PRIVATE_VARIABLES

        /// <summary>
        /// Defines the _loginService.
        /// </summary>
        private readonly ILoginService _loginService;

        #endregion

        #region PUBLIC_PPTY

        /// <summary>
        /// Gets or sets the LoginCommand.
        /// </summary>
        public ICommand LoginCommand { protected set; get; }

        public ICommand LoginCommand1 { protected set; get; }

        /// <summary>
        /// Gets or sets the Password.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the UserName.
        /// </summary>
        public string UserName { get; set; }

        public ICommand NewUserCommand { protected set; get; }

        #endregion

        #region CONSTRUCTOR

        /// <summary>
        /// Initializes a new instance of the <see cref="LoginPageViewModel"/> class.
        /// </summary>
        /// <param name="loginService">The loginService<see cref="ILoginService"/>.</param>
        public LoginPageViewModel(ILoginService loginService)
        {
            _loginService = loginService;
            _loginService.RegisterDefaultUser();
            LoginCommand1 = new Command(NewUser);
            LoginCommand = new Command(Login);
        }

        private void NewUser()
        {
            var vm = IocContainer.Resolve<RegistrationViewModel>();
            Application.Current.MainPage.Navigation.PushAsync(new UserRegistrationPage { BindingContext = vm });
        }

        #endregion

        #region PRIVATE_METHODS

        /// <summary>
        /// The Login.
        /// </summary>
        private void Login()
        {
            if (string.IsNullOrEmpty(UserName) || string.IsNullOrEmpty(Password))
            {
                Application.Current.MainPage.DisplayAlert(
                   "Login Failed",
                   "Please Enter username and password",
                   "Ok");
                return;
            }
            var result = _loginService.Login(UserName, Password).GetAwaiter().GetResult();
            if (result)
            {
                var vm = IocContainer.Resolve<StoreMainPageViewModel>();
                Application.Current.MainPage.Navigation.PushAsync(new StoreMainPage { BindingContext = vm });
            }
            else
            {
                // show dialog
                Application.Current.MainPage.DisplayAlert(
                    "Login Failed",
                    "Invalid Credential",
                    "Ok");
            }
        }

        #endregion
    }
}
