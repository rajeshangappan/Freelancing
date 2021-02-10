using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamSample.ViewModel;

namespace XamSample.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NavItemPage : ContentPage
    {
        public NavItemPage()
        {
            InitializeComponent();
        }
    }
}