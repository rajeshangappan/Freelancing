using System.Collections.Generic;

namespace XamSample.Models
{
    /// <summary>
    /// Defines the <see cref="SyncRequest" />.
    /// </summary>
    public class SyncRequest
    {
        #region Properties

        /// <summary>
        /// Gets or sets the OfflineVersion.
        /// </summary>
        public long OfflineVersion { get; set; }

        /// <summary>
        /// Gets or sets the Products.
        /// </summary>
        public List<Product> Products { get; set; }

        #endregion
    }
}
