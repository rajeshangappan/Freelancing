﻿using Foundation;
using UIKit;

namespace XamSample.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    /// <summary>
    /// Defines the <see cref="AppDelegate" />.
    /// </summary>
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        #region Methods

        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        /// <summary>
        /// The FinishedLaunching.
        /// </summary>
        /// <param name="app">The app<see cref="UIApplication"/>.</param>
        /// <param name="options">The options<see cref="NSDictionary"/>.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }

        #endregion
    }
}
