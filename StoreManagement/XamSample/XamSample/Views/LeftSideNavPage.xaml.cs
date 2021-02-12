using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamSample.Views
{
    /// <summary>
    /// Defines the <see cref="LeftSideNavPage" />.
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LeftSideNavPage : ContentPage
    {
        #region Fields

        /// <summary>
        /// Defines the ListView.
        /// </summary>
        public ListView ListView;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="LeftSideNavPage"/> class.
        /// </summary>
        public LeftSideNavPage()
        {
            InitializeComponent();
        }

        #endregion
    }
}
