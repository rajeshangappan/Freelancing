using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using XamSample.AppHelper;
using XamSample.Contracts;
using XamSample.Services;
using XamSample.Views;

namespace XamSample.ViewModel
{
    /// <summary>
    /// Defines the <see cref="RegistrationViewModel" />.
    /// </summary>
    public class RegistrationViewModel
    {
        #region Fields

        /// <summary>
        /// Defines the _loginService.
        /// </summary>
        private readonly ILoginService _loginService;

        /// <summary>
        /// Defines the _navigation.
        /// </summary>
        private NavigationService _navigation;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="RegistrationViewModel"/> class.
        /// </summary>
        /// <param name="loginService">The loginService<see cref="ILoginService"/>.</param>
        /// <param name="navigationService">The navigationService<see cref="NavigationService"/>.</param>
        public RegistrationViewModel(ILoginService loginService, NavigationService navigationService)
        {
            _loginService = loginService;
            _navigation = navigationService;
            SignupCommand = new Command(async (obj) => await SignUP(obj));
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the Password.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the RePassword.
        /// </summary>
        public string RePassword { get; set; }

        /// <summary>
        /// Gets or sets the SignupCommand.
        /// </summary>
        public ICommand SignupCommand { protected set; get; }

        /// <summary>
        /// Gets or sets the UserName.
        /// </summary>
        public string UserName { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// The NavigatetoMainPage.
        /// </summary>
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

        /// <summary>
        /// The SignUP.
        /// </summary>
        /// <param name="obj">The obj<see cref="object"/>.</param>
        /// <returns>The <see cref="Task"/>.</returns>
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

        #endregion
    }
}
