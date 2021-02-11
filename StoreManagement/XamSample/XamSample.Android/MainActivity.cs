﻿using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using XamSample.Services;
using XamSample.AppHelper;
using XamSample.Contracts.Services;
using System.Reflection;

namespace XamSample.Droid
{
    [Activity(Label = "AppTemplate", Icon = "@mipmap/icon", Theme = "@style/MainTheme", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
           // InitializeNLog();
            LoadApplication(new App());
           //this.Bootstraping();
          //  this.Bootstraping();
        }

        
    }
}