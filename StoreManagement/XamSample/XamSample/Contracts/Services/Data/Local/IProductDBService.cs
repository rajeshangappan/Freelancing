﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using XamSample.Models;
using XamSample.Models.DAO;

namespace XamSample.Contracts
{
    #region Interfaces

    /// <summary>
    /// Defines the <see cref="IProductDBService" />.
    /// </summary>
    public interface IProductDBService
    {
        #region Methods

        /// <summary>
        /// The AddProducts.
        /// </summary>
        /// <param name="product">The product<see cref="ProductDAO"/>.</param>
        /// <returns>The <see cref="Task{int}"/>.</returns>
        Task<int> AddProducts(ProductDAO product);

        /// <summary>
        /// The AddProductsFromOnline.
        /// </summary>
        /// <param name="product">The product<see cref="ProductDAO"/>.</param>
        /// <returns>The <see cref="Task{int}"/>.</returns>
        Task<int> AddProductsFromOnline(ProductDAO product);

        /// <summary>
        /// The DeleteProduct.
        /// </summary>
        /// <param name="product">The product<see cref="Product"/>.</param>
        /// <returns>The <see cref="Task{int}"/>.</returns>
        Task<int> DeleteProduct(Product product);

        /// <summary>
        /// The GetLatestVersion.
        /// </summary>
        /// <returns>The <see cref="Task{long}"/>.</returns>
        Task<long> GetLatestVersion();

        /// <summary>
        /// The GetOfflineProducts.
        /// </summary>
        /// <returns>The <see cref="Task{List{ProductDAO}}"/>.</returns>
        Task<List<ProductDAO>> GetOfflineProducts();

        /// <summary>
        /// The GetProduct.
        /// </summary>
        /// <param name="id">The id<see cref="Guid"/>.</param>
        /// <returns>The <see cref="Task{Product}"/>.</returns>
        Task<Product> GetProduct(Guid id);

        /// <summary>
        /// The GetProducts.
        /// </summary>
        /// <returns>The <see cref="Task{List{Product}}"/>.</returns>
        Task<List<Product>> GetProducts();

        /// <summary>
        /// The Updateproduct.
        /// </summary>
        /// <param name="product">The product<see cref="ProductDAO"/>.</param>
        /// <returns>The <see cref="Task{int}"/>.</returns>
        Task<int> Updateproduct(ProductDAO product);

        /// <summary>
        /// The UpdateproductFromOnline.
        /// </summary>
        /// <param name="product">The product<see cref="ProductDAO"/>.</param>
        /// <returns>The <see cref="Task{int}"/>.</returns>
        Task<int> UpdateproductFromOnline(ProductDAO product);

        #endregion
    }

    #endregion
}
