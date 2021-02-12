using System.Reflection;

namespace XamSample.DependencyServices
{
    #region Interfaces

    /// <summary>
    /// Defines the <see cref="IFileHelper" />.
    /// </summary>
    public interface IFileHelper
    {
        #region Methods

        /// <summary>
        /// The GetAssemblyDetails.
        /// </summary>
        /// <returns>The <see cref="Assembly"/>.</returns>
        Assembly GetAssemblyDetails();

        #endregion
    }

    #endregion
}
