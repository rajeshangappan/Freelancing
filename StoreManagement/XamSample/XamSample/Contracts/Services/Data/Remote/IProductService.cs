using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using XamSample.Models;

namespace XamSample.Contracts
{
    #region Interfaces

    /// <summary>
    /// Defines the <see cref="IProductService" />.
    /// </summary>
    public interface IProductService
    {
        #region Methods

        /// <summary>
        /// The AddProducts.
        /// </summary>
        /// <param name="product">The product<see cref="Product"/>.</param>
        /// <returns>The <see cref="Task{bool}"/>.</returns>
        Task<bool> AddProducts(Product product);

        /// <summary>
        /// The DeleteProduct.
        /// </summary>
        /// <param name="product">The product<see cref="Product"/>.</param>
        /// <returns>The <see cref="Task{bool}"/>.</returns>
        Task<bool> DeleteProduct(Product product);

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
        /// <param name="product">The product<see cref="Product"/>.</param>
        /// <returns>The <see cref="Task{bool}"/>.</returns>
        Task<bool> Updateproduct(Product product);

        #endregion
    }

    #endregion
}
