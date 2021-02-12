using UIKit;

namespace XamSample.iOS
{
    /// <summary>
    /// Defines the <see cref="Application" />.
    /// </summary>
    public class Application
    {
        #region Methods

        // This is the main entry point of the application.
        /// <summary>
        /// The Main.
        /// </summary>
        /// <param name="args">The args<see cref="string[]"/>.</param>
        internal static void Main(string[] args)
        {
            // if you want to use a different Application Delegate class from "AppDelegate"
            // you can specify it here.
            UIApplication.Main(args, null, "AppDelegate");
        }

        #endregion
    }
}
