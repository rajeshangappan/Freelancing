﻿using SQLite;
using System;

namespace XamSample.Models.DAO
{
    /// <summary>
    /// Defines the <see cref="ProductDAO" />.
    /// </summary>
    [Table("Product")]
    public class ProductDAO
    {
        #region Properties

        /// <summary>
        /// Gets or sets the AvailableQty.
        /// </summary>
        public int AvailableQty { get; set; }

        /// <summary>
        /// Gets or sets the Cost.
        /// </summary>
        public double Cost { get; set; }

        /// <summary>
        /// Gets or sets the Id.
        /// </summary>
        [PrimaryKey]
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether IsDeleted.
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Gets or sets the MaxLimit.
        /// </summary>
        public int MaxLimit { get; set; }

        /// <summary>
        /// Gets or sets the ProdName.
        /// </summary>
        public string ProdName { get; set; }

        /// <summary>
        /// Gets or sets the UpdatedAt.
        /// </summary>
        public DateTime UpdatedAt { get; set; }

        /// <summary>
        /// Gets or sets the Version.
        /// </summary>
        public long Version { get; set; }

        #endregion
    }
}
