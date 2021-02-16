using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using XamSample.AppHelper;
using XamSample.Contracts.Services;
using XamSample.Services;
using XamSample.Views;

namespace XamSample.ViewModel
{
    /// <summary>
    /// Defines the <see cref="HomeMasterPageMasterMenuItem" />.
    /// </summary>
    public class HomeMasterPageMasterMenuItem
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="HomeMasterPageMasterMenuItem"/> class.
        /// </summary>
        public HomeMasterPageMasterMenuItem()
        {
            TargetType = typeof(HomeMasterPageMasterMenuItem);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the Id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the TargetType.
        /// </summary>
        public Type TargetType { get; set; }

        /// <summary>
        /// Gets or sets the Title.
        /// </summary>
        public string Title { get; set; }

        #endregion
    }

    /// <summary>
    /// Defines the <see cref="LeftSideNavPageViewModel" />.
    /// </summary>
    public class LeftSideNavPageViewModel : ViewModelBase
    {
        #region Fields

        /// <summary>
        /// Defines the _navigation.
        /// </summary>
        private NavigationService _navigation;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="LeftSideNavPageViewModel"/> class.
        /// </summary>
        /// <param name="navigation">The navigation<see cref="NavigationService"/>.</param>
        /// <param name="logService">The logService<see cref="ILogService"/>.</param>
        public LeftSideNavPageViewModel(NavigationService navigation, ILogService logService) : base(logService)
        {
            _navigation = navigation;
            MenuItems = new ObservableCollection<HomeMasterPageMasterMenuItem>(new[]
            {
                    new HomeMasterPageMasterMenuItem { Id = 0, Title = "My Profile" },
                    new HomeMasterPageMasterMenuItem { Id = 1, Title = "My Ads" },
                    new HomeMasterPageMasterMenuItem { Id = 2, Title = "Products" },
                    new HomeMasterPageMasterMenuItem { Id = 3, Title = "Posts" },
                    new HomeMasterPageMasterMenuItem { Id = 4, Title = "Logs" },
                });
            OnListSelectedCommad = new Command<object>(async (x) => await OnItemSelected(x));
        }

        #endregion

        #region Events

        /// <summary>
        /// Defines the PropertyChanged.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the CurrentUser.
        /// </summary>
        public string CurrentUser { get; set; } = SampleHelper.CurrentUser;

        /// <summary>
        /// Gets or sets the MenuItems.
        /// </summary>
        public ObservableCollection<HomeMasterPageMasterMenuItem> MenuItems { get; set; }

        /// <summary>
        /// Gets or sets the OnListSelectedCommad.
        /// </summary>
        public ICommand OnListSelectedCommad { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// The OnPropertyChanged.
        /// </summary>
        /// <param name="propertyName">The propertyName<see cref="string"/>.</param>
        internal void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged == null)
                return;

            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// The NavigateToItem.
        /// </summary>
        /// <param name="selectedItem">The selectedItem<see cref="string"/>.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        private async Task NavigateToItem(string selectedItem)
        {
            var navItemVM = IocContainer.Resolve<NavItemPageViewModel>();
            navItemVM.SelectedItem = selectedItem;
            await _navigation.NavigateAsync(new NavItemPage { BindingContext = navItemVM });
        }

        private async Task NavigateToLogPage(HomeMasterPageMasterMenuItem item)
        {
            var logVM = IocContainer.Resolve<LoggerPageViewModel>();
            await _navigation.NavigateAsync(new LoggerPage { BindingContext = logVM });
        }

        /// <summary>
        /// The OnItemSelected.
        /// </summary>
        /// <param name="seletedItem">The seletedItem<see cref="object"/>.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        private async Task OnItemSelected(object seletedItem)
        {
            var args = seletedItem as SelectedItemChangedEventArgs;
            var selectedObj = args.SelectedItem as HomeMasterPageMasterMenuItem;
            _navigation.HideLeftNavigationPanal();
            if (selectedObj.Id == 4)
            {
                await NavigateToLogPage(selectedObj);
            }
            else
            {
                await NavigateToItem(selectedObj.Title);
            }

        }

        #endregion
    }
}
