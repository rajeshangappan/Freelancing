﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using XamSample.AppHelper;
using XamSample.Contracts;
using XamSample.Services;
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
        private NavigationService _navigation;
        public RegistrationViewModel(ILoginService loginService, NavigationService navigationService)
        {
            _loginService = loginService;
            _navigation = navigationService;
            SignupCommand = new Command(async (obj) => await SignUP(obj));
        }

        private async Task SignUP(object obj)
        {
            if (!string.IsNullOrEmpty(UserName) && !string.IsNullOrEmpty(Password))
            {
                if (Password == RePassword)
                {
                    bool isRegistered =_loginService.Register(UserName, Password).GetAwaiter().GetResult();
                    if (isRegistered)
                    {
                        NavigatetoMainPage();
                        //Application.Current.MainPage.Navigation.PushAsync(new StoreMainPage { BindingContext = vm });
                    }
                    else
                    {
                        // show dialog
                        await Application.Current.MainPage.DisplayAlert(
                            "Registration Failed",
                            "User name already exists",
                            "Ok");
                    }
                }
                else
                {
                    // show dialog
                    await Application.Current.MainPage.DisplayAlert(
                        "Login Failed",
                        "Password mismatched",
                        "Ok");
                }
            }
            else
            {
                // show dialog
                await Application.Current.MainPage.DisplayAlert(
                    "Login Failed",
                    "user name and password is mandatory",
                    "Ok");
            }

        }
        private void NavigatetoMainPage()
        {
            var masterpage = new HomeMasterPage();
            var vm = IocContainer.Resolve<StoreMainPageViewModel>();
            var mastervm = IocContainer.Resolve<LeftSideNavPageViewModel>();
            masterpage.Master = new LeftSideNavPage { BindingContext = mastervm };
            masterpage.Detail = new NavigationPage(new StoreMainPage { BindingContext = vm });
            (masterpage.Detail as NavigationPage).BarBackgroundColor = Color.FromHex("#20C3B0");
            Application.Current.MainPage = masterpage;
        }
    }
}
