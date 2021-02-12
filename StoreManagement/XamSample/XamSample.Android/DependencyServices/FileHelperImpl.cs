using System.Reflection;
using XamSample.DependencyServices;


[assembly: Xamarin.Forms.Dependency(typeof(XamSample.Droid.DependencyServices.FileHelperImpl))]
namespace XamSample.Droid.DependencyServices
{
    /// <summary>
    /// Defines the <see cref="FileHelperImpl" />.
    /// </summary>
    public class FileHelperImpl : IFileHelper
    {
        #region Methods

        /// <summary>
        /// The GetAssemblyDetails.
        /// </summary>
        /// <returns>The <see cref="Assembly"/>.</returns>
        public Assembly GetAssemblyDetails()
        {
            return this.GetType().Assembly;
        }

        #endregion
    }
}
