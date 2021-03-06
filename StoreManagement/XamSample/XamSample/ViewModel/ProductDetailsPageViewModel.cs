﻿using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using XamSample.AppHelper;
using XamSample.Contracts;
using XamSample.Models;
using XamSample.Services;

namespace XamSample.ViewModel
{
    /// <summary>
    /// Defines the <see cref="ProductDetailsPageViewModel" />.
    /// </summary>
    public class ProductDetailsPageViewModel
    {
        #region Fields

        /// <summary>
        /// Defines the _navigation.
        /// </summary>
        private NavigationService _navigation;

        /// <summary>
        /// Defines the _productService.
        /// </summary>
        private IProductService _productService;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductDetailsPageViewModel"/> class.
        /// </summary>
        /// <param name="productService">The productService<see cref="IProductService"/>.</param>
        /// <param name="navigationService">The navigationService<see cref="NavigationService"/>.</param>
        public ProductDetailsPageViewModel(IProductService productService, NavigationService navigationService)
        {
            _productService = productService;
            _navigation = navigationService;
            IsAdmin = SampleHelper.IsAdmin();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the DeleteCommand.
        /// </summary>
        public ICommand DeleteCommand => new Command(async () => await DeleteProduct());

        /// <summary>
        /// Gets a value indicating whether EnableDelete.
        /// </summary>
        public bool EnableDelete => IsAdmin && !IsNewProduct;

        /// <summary>
        /// Gets or sets a value indicating whether IsAdmin.
        /// </summary>
        public bool IsAdmin { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether IsNewProduct.
        /// </summary>
        public bool IsNewProduct { get; set; }

        /// <summary>
        /// Gets or sets the Product.
        /// </summary>
        public Product Product { get; set; }

        /// <summary>
        /// Gets the SaveChangesCommand.
        /// </summary>
        public ICommand SaveChangesCommand => new Command(async () => await SaveChanges());

        #endregion

        #region Methods

        /// <summary>
        /// The DeleteProduct.
        /// </summary>
        /// <returns>The <see cref="Task"/>.</returns>
        private async Task DeleteProduct()
        {
            var result = await _productService.DeleteProduct(Product);
            if (result)
            {
                await Application.Current.MainPage.DisplayAlert("", "Product Deleted Succesfully", "ok");
                //await Application.Current.MainPage.Navigation.PopAsync();
                await _navigation.PopAsync();
            }
        }

        /// <summary>
        /// The SaveChanges.
        /// </summary>
        /// <returns>The <see cref="Task"/>.</returns>
        private async Task SaveChanges()
        {
            if (await validation())
            {
                if (IsNewProduct && SampleHelper.IsAdmin())
                {
                    var result = await _productService.AddProducts(Product);
                    if (result)
                    {
                        await Application.Current.MainPage.DisplayAlert("", "Product Added Succesfully", "ok");
                        await _navigation.PopAsync();
                        //await Application.Current.MainPage.Navigation.PopAsync();
                    }
                }
                else if (!IsNewProduct)
                {
                    var result = await _productService.Updateproduct(Product);
                    if (result)
                    {
                        await Application.Current.MainPage.DisplayAlert("", "Product Updated Succesfully", "ok");
                        await _navigation.PopAsync();
                        // await Application.Current.MainPage.Navigation.PopAsync();
                    }
                }
            }
        }

        /// <summary>
        /// The validation.
        /// </summary>
        /// <returns>The <see cref="Task{bool}"/>.</returns>
        private async Task<bool> validation()
        {
            if (string.IsNullOrEmpty(Product.ProdName) || Product.Cost == 0)
            {
                await Application.Current.MainPage.DisplayAlert(
                string.Empty,
                "Product name and Cost is mandatory",
                "Ok");
                return false;
            }
            return true;
        }

        #endregion
    }
}
