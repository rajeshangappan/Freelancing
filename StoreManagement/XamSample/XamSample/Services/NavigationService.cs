using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamSample.AppHelper;
using XamSample.ViewModel;
using XamSample.Views;

namespace XamSample.Services
{
    public class NavigationService
    {
        public async Task NavigateAsync(ContentPage page)
        {
            var navpage = (Application.Current.MainPage as MasterDetailPage).Detail as NavigationPage;
            await navpage.PushAsync(page);
        }

        public async Task PopAsync()
        {
            var navpage = (Application.Current.MainPage as MasterDetailPage).Detail as NavigationPage;
            await navpage.PopAsync();
        }

        public void NavigateToLoginPage()
        {
            var login = IocContainer.Resolve<LoginPageViewModel>();
            Application.Current.MainPage = new NavigationPage(new LoginPage { BindingContext = login });
        }

        public void HideLeftNavigationPanal()
        {
            if(Application.Current.MainPage is HomeMasterPage masterPage)
            {
                masterPage.IsPresented = false;

            }
        }
    }
}
