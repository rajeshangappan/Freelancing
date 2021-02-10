﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamSample.AppHelper;
using XamSample.ViewModel;

namespace XamSample.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LeftSideNavPage : ContentPage
    {
        public ListView ListView;

        public LeftSideNavPage()
        {
            InitializeComponent();            
        }
    }
    
}