namespace XamSample.AppHelper
{
    /// <summary>
    /// Defines the <see cref="SampleHelper" />.
    /// </summary>
    public class SampleHelper
    {
        #region Properties

        /// <summary>
        /// Gets or sets the CurrentUser.
        /// </summary>
        public static string CurrentUser { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// The IsAdmin.
        /// </summary>
        /// <returns>The <see cref="bool"/>.</returns>
        public static bool IsAdmin()
        {
            return Xamarin.Essentials.SecureStorage.GetAsync("role").GetAwaiter().GetResult() == "admin";
        }

        #endregion
    }
}
