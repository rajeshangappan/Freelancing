using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using XamSample.AppHelper;
using XamSample.Services;
using XamSample.Views;

namespace XamSample.ViewModel
{
    /// <summary>
    /// Defines the <see cref="StoreMainPageViewModel" />.
    /// </summary>
    public class StoreMainPageViewModel
    {
        #region Fields

        /// <summary>
        /// Defines the _navigation.
        /// </summary>
        private NavigationService _navigation;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="StoreMainPageViewModel"/> class.
        /// </summary>
        /// <param name="navigationService">The navigationService<see cref="NavigationService"/>.</param>
        public StoreMainPageViewModel(NavigationService navigationService)
        {
            _navigation = navigationService;
            IsAdmin = SampleHelper.IsAdmin();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets a value indicating whether IsAdmin.
        /// </summary>
        public bool IsAdmin { get; set; }

        /// <summary>
        /// Gets the LogoutCommand.
        /// </summary>
        public ICommand LogoutCommand => new Command(OnLogout);

        /// <summary>
        /// Gets the ProductClickCommand.
        /// </summary>
        public ICommand ProductClickCommand => new Command(async () => await OnProductClicked());

        /// <summary>
        /// Gets the StaffClickCommand.
        /// </summary>
        public ICommand StaffClickCommand => new Command(async () => await OnStaffClicked());

        #endregion

        #region Methods

        /// <summary>
        /// The OnLogout.
        /// </summary>
        /// <param name="obj">The obj<see cref="object"/>.</param>
        private void OnLogout(object obj)
        {
            //Logout API and pop this page
            Application.Current.Properties.Clear();
            _navigation.NavigateToLoginPage();
        }

        /// <summary>
        /// The OnProductClicked.
        /// </summary>
        /// <returns>The <see cref="Task"/>.</returns>
        private async Task OnProductClicked()
        {
            var vm = IocContainer.Resolve<ProductViewModel>();
            //var navpage = (Application.Current.MainPage as MasterDetailPage).Detail as NavigationPage;
            //await navpage.PushAsync(new ProductPage { BindingContext = vm });
            await _navigation.NavigateAsync(new ProductPage { BindingContext = vm });
        }

        /// <summary>
        /// The OnStaffClicked.
        /// </summary>
        /// <returns>The <see cref="Task"/>.</returns>
        private async Task OnStaffClicked()
        {
            var vm = IocContainer.Resolve<StaffPageViewModel>();
            //await Application.Current.MainPage.Navigation.PushAsync(new StaffPage { BindingContext = vm });
            await _navigation.NavigateAsync(new StaffPage { BindingContext = vm });
        }

        #endregion
    }
}
