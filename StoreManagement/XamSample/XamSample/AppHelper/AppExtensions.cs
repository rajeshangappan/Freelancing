using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace XamSample.AppHelper
{
    /// <summary>
    /// Defines the <see cref="AppExtensions" />.
    /// </summary>
    public static class AppExtensions
    {
        #region Methods

        /// <summary>
        /// The ToObservableCollection.
        /// </summary>
        /// <typeparam name="T">.</typeparam>
        /// <param name="enumerable">The enumerable<see cref="IEnumerable{T}"/>.</param>
        /// <returns>The <see cref="ObservableCollection{T}"/>.</returns>
        public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> enumerable)
        {
            return new ObservableCollection<T>(enumerable);
        }

        #endregion
    }
}
