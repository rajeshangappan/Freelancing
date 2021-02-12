using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.App;
using Android.Util;

namespace XamSample.Droid
{
    /// <summary>
    /// Defines the <see cref="SplashActivity" />.
    /// </summary>
    [Activity(Theme = "@style/MyTheme.Splash", MainLauncher = true, NoHistory = true)]
    public class SplashActivity : AppCompatActivity
    {
        #region Fields

        /// <summary>
        /// Defines the TAG.
        /// </summary>
        internal static readonly string TAG = "X:" + typeof(SplashActivity).Name;

        #endregion

        #region Methods

        /// <summary>
        /// The OnCreate.
        /// </summary>
        /// <param name="savedInstanceState">The savedInstanceState<see cref="Bundle"/>.</param>
        /// <param name="persistentState">The persistentState<see cref="PersistableBundle"/>.</param>
        public override void OnCreate(Bundle savedInstanceState, PersistableBundle persistentState)
        {
            base.OnCreate(savedInstanceState, persistentState);
            Log.Debug(TAG, "SplashActivity.OnCreate");
        }

        // Launches the startup task
        /// <summary>
        /// The OnResume.
        /// </summary>
        protected override void OnResume()
        {
            base.OnResume();
            //Task startupWork = new Task(() => { SimulateStartup(); });
            //startupWork.Start();
            StartActivity(new Intent(Application.Context, typeof(MainActivity)));
        }

        #endregion
    }
}
