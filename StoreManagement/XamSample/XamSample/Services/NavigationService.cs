using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamSample.AppHelper;

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
    }
}
