using Android.App;
using Android.Content.PM;
using Android.OS;

namespace XamSample.Droid
{
    /// <summary>
    /// Defines the <see cref="MainActivity" />.
    /// </summary>
    [Activity(Label = "AppTemplate", Icon = "@mipmap/icon", Theme = "@style/MainTheme", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        #region Methods

        /// <summary>
        /// The OnCreate.
        /// </summary>
        /// <param name="savedInstanceState">The savedInstanceState<see cref="Bundle"/>.</param>
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            // InitializeNLog();
            LoadApplication(new App());
        }

        #endregion
    }
}
