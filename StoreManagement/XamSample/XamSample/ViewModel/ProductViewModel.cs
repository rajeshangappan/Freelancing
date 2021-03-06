﻿using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using XamSample.AppHelper;
using XamSample.Contracts;
using XamSample.Models;
using XamSample.Services;
using XamSample.Views;

namespace XamSample.ViewModel
{
    /// <summary>
    /// Defines the <see cref="ProductViewModel" />.
    /// </summary>
    public class ProductViewModel : INotifyPropertyChanged
    {
        #region Fields

        /// <summary>
        /// Defines the _navigation.
        /// </summary>
        private NavigationService _navigation;

        /// <summary>
        /// Defines the _productList.
        /// </summary>
        private ObservableCollection<Product> _productList;

        /// <summary>
        /// Defines the _productService.
        /// </summary>
        private IProductService _productService;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductViewModel"/> class.
        /// </summary>
        /// <param name="productService">The productService<see cref="IProductService"/>.</param>
        /// <param name="navigationService">The navigationService<see cref="NavigationService"/>.</param>
        public ProductViewModel(IProductService productService, NavigationService navigationService)
        {
            _productService = productService;
            _navigation = navigationService;
            IsAdmin = SampleHelper.IsAdmin();
        }

        #endregion

        #region Events

        /// <summary>
        /// Defines the PropertyChanged.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Properties

        /// <summary>
        /// Gets the AddProductCommand.
        /// </summary>
        public ICommand AddProductCommand => new Command(async () => await OnAddProduct());

        /// <summary>
        /// Gets or sets a value indicating whether IsAdmin.
        /// </summary>
        public bool IsAdmin { get; set; }

        /// <summary>
        /// Gets the ItemSelectedCommand.
        /// </summary>
        public ICommand ItemSelectedCommand => new Command(async () => await OnItemSelected());

        /// <summary>
        /// Gets the OnAppearingCommand.
        /// </summary>
        public ICommand OnAppearingCommand => new Command(async () => await OnAppearing());

        /// <summary>
        /// Gets or sets the ProductList.
        /// </summary>
        public ObservableCollection<Product> ProductList
        {
            get => _productList;
            set
            {
                if (_productList != value)
                {
                    _productList = value;
                }

                OnPropertyChanged("ProductList");
            }
        }

        /// <summary>
        /// Gets or sets the SelectedProduct.
        /// </summary>
        public Product SelectedProduct { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// The NavigateToProduct.
        /// </summary>
        /// <param name="product">The product<see cref="Product"/>.</param>
        /// <param name="IsNewProduct">The IsNewProduct<see cref="bool"/>.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        private async Task NavigateToProduct(Product product, bool IsNewProduct)
        {
            var vm = IocContainer.Resolve<ProductDetailsPageViewModel>();
            vm.Product = product;
            vm.IsAdmin = IsAdmin;
            vm.IsNewProduct = IsNewProduct;
            await _navigation.NavigateAsync(new ProductDetailsPage { BindingContext = vm });
        }

        /// <summary>
        /// The OnAddProduct.
        /// </summary>
        /// <returns>The <see cref="Task"/>.</returns>
        private async Task OnAddProduct()
        {
            await NavigateToProduct(new Product(), true);
        }

        /// <summary>
        /// The OnAppearing.
        /// </summary>
        /// <returns>The <see cref="Task"/>.</returns>
        private async Task OnAppearing()
        {
            var products = await _productService.GetProducts();
            ProductList = products.ToObservableCollection();
        }

        /// <summary>
        /// The OnItemSelected.
        /// </summary>
        /// <returns>The <see cref="Task"/>.</returns>
        private async Task OnItemSelected()
        {
            await NavigateToProduct(SelectedProduct, false);
        }

        /// <summary>
        /// The OnPropertyChanged.
        /// </summary>
        /// <param name="propertyName">The propertyName<see cref="string"/>.</param>
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
