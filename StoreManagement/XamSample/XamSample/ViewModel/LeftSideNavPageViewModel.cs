using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using XamSample.AppHelper;
using XamSample.Services;
using XamSample.Views;

namespace XamSample.ViewModel
{
    public class LeftSideNavPageViewModel : ViewModelBase
    {
        public ObservableCollection<HomeMasterPageMasterMenuItem> MenuItems { get; set; }
        public string CurrentUser { get; set; } = SampleHelper.CurrentUser;

        public ICommand OnListSelectedCommad { get; set; }

        private NavigationService _navigation;

        public LeftSideNavPageViewModel(NavigationService navigation)
        {
            _navigation = navigation;
            MenuItems = new ObservableCollection<HomeMasterPageMasterMenuItem>(new[]
            {
                    new HomeMasterPageMasterMenuItem { Id = 0, Title = "My Profile" },
                    new HomeMasterPageMasterMenuItem { Id = 1, Title = "My Ads" },
                    new HomeMasterPageMasterMenuItem { Id = 2, Title = "Products" },
                    new HomeMasterPageMasterMenuItem { Id = 3, Title = "Posts" },
                });
            OnListSelectedCommad = new Command<object>(async (x) => await OnItemSelected(x));
        }

        private async Task OnItemSelected(object seletedItem)
        {
            var args = seletedItem as SelectedItemChangedEventArgs;
            _navigation.HideLeftNavigationPanal();
            await NavigateToItem((args.SelectedItem as HomeMasterPageMasterMenuItem).Title);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged == null)
                return;

            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private async Task NavigateToItem(string selectedItem)
        {
            var navItemVM = IocContainer.Resolve<NavItemPageViewModel>();
            navItemVM.SelectedItem = selectedItem;
            await _navigation.NavigateAsync(new NavItemPage { BindingContext = navItemVM });
        }
    }
    public class HomeMasterPageMasterMenuItem
    {
        public HomeMasterPageMasterMenuItem()
        {
            TargetType = typeof(HomeMasterPageMasterMenuItem);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}

