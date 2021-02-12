using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamSample.Views
{
    /// <summary>
    /// Defines the <see cref="HomeMasterPage" />.
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomeMasterPage : MasterDetailPage
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="HomeMasterPage"/> class.
        /// </summary>
        public HomeMasterPage()
        {
            InitializeComponent();

            this.IsPresented = false;
        }

        #endregion
    }
}
