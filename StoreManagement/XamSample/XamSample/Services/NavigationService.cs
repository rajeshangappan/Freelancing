using System.Threading.Tasks;
using Xamarin.Forms;
using XamSample.AppHelper;
using XamSample.ViewModel;
using XamSample.Views;

namespace XamSample.Services
{
    /// <summary>
    /// Defines the <see cref="NavigationService" />.
    /// </summary>
    public class NavigationService
    {
        #region Methods

        /// <summary>
        /// The HideLeftNavigationPanal.
        /// </summary>
        public void HideLeftNavigationPanal()
        {
            if (Application.Current.MainPage is HomeMasterPage masterPage)
            {
                masterPage.IsPresented = false;

            }
        }

        /// <summary>
        /// The NavigateAsync.
        /// </summary>
        /// <param name="page">The page<see cref="ContentPage"/>.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        public async Task NavigateAsync(ContentPage page)
        {
            var navpage = (Application.Current.MainPage as MasterDetailPage).Detail as NavigationPage;
            await navpage.PushAsync(page);
        }

        /// <summary>
        /// The NavigateToLoginPage.
        /// </summary>
        public void NavigateToLoginPage()
        {
            var login = IocContainer.Resolve<LoginPageViewModel>();
            Application.Current.MainPage = new NavigationPage(new LoginPage { BindingContext = login });
        }

        /// <summary>
        /// The PopAsync.
        /// </summary>
        /// <returns>The <see cref="Task"/>.</returns>
        public async Task PopAsync()
        {
            var navpage = (Application.Current.MainPage as MasterDetailPage).Detail as NavigationPage;
            await navpage.PopAsync();
        }

        #endregion
    }
}
