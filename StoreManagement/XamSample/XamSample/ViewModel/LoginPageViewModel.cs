using System.Windows.Input;
using Xamarin.Forms;
using XamSample.AppHelper;
using XamSample.Contracts;
using XamSample.Contracts.Services;
using XamSample.Views;

namespace XamSample.ViewModel
{
    /// <summary>
    /// Defines the <see cref="LoginPageViewModel" />.
    /// </summary>
    public class LoginPageViewModel : ViewModelBase
    {
        #region Fields

        /// <summary>
        /// Defines the _loginService.
        /// </summary>
        private readonly ILoginService _loginService;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="LoginPageViewModel"/> class.
        /// </summary>
        /// <param name="loginService">The loginService<see cref="ILoginService"/>.</param>
        /// <param name="logService">The logService<see cref="ILogService"/>.</param>
        public LoginPageViewModel(ILoginService loginService, ILogService logService) : base(logService)
        {
            _loginService = loginService;
            _loginService.RegisterDefaultUser();
            LoginCommand1 = new Command(NewUser);
            LoginCommand = new Command(Login);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the LoginCommand.
        /// </summary>
        public ICommand LoginCommand { protected set; get; }

        /// <summary>
        /// Gets or sets the LoginCommand1.
        /// </summary>
        public ICommand LoginCommand1 { protected set; get; }

        /// <summary>
        /// Gets or sets the NewUserCommand.
        /// </summary>
        public ICommand NewUserCommand { protected set; get; }

        /// <summary>
        /// Gets or sets the Password.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the UserName.
        /// </summary>
        public string UserName { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// The Login.
        /// </summary>
        private void Login()
        {
            LogService.LogInfo("Login Initiated");
            if (string.IsNullOrEmpty(UserName) || string.IsNullOrEmpty(Password))
            {
                LogService.LogInfo("Login Failed");
                Application.Current.MainPage.DisplayAlert(
                   "Login Failed",
                   "Please Enter username and password",
                   "Ok");
                return;
            }
            var result = _loginService.Login(UserName, Password).GetAwaiter().GetResult();
            if (result)
            {
                LogService.LogInfo("Login Success");
                SampleHelper.CurrentUser = UserName;
                //var vm = IocContainer.Resolve<StoreMainPageViewModel>();
                //Application.Current.MainPage.Navigation.PushAsync(new StoreMainPage { BindingContext = vm });
                NavigatetoMainPage();
            }
            else
            {
                LogService.LogInfo("Login Failed");
                // show dialog
                Application.Current.MainPage.DisplayAlert(
                    "Login Failed",
                    "Invalid Credential",
                    "Ok");
            }
        }

        /// <summary>
        /// The NavigatetoMainPage.
        /// </summary>
        private void NavigatetoMainPage()
        {
            LogService.LogInfo("Navigate to main page");
            var masterpage = new HomeMasterPage();
            var vm = IocContainer.Resolve<StoreMainPageViewModel>();
            var mastervm = IocContainer.Resolve<LeftSideNavPageViewModel>();
            //Application.Current.MainPage.Navigation.PushAsync(new StoreMainPage { BindingContext = vm });
            masterpage.Master = new LeftSideNavPage { BindingContext = mastervm };
            masterpage.Detail = new NavigationPage(new StoreMainPage { BindingContext = vm });
            (masterpage.Detail as NavigationPage).BarBackgroundColor = Color.FromHex("#20C3B0");
            Application.Current.MainPage = masterpage;
        }

        /// <summary>
        /// The NewUser.
        /// </summary>
        private void NewUser()
        {
            LogService.LogInfo("New User Clicked");
            var vm = IocContainer.Resolve<RegistrationViewModel>();
            Application.Current.MainPage.Navigation.PushAsync(new UserRegistrationPage { BindingContext = vm });
        }

        #endregion
    }
}
