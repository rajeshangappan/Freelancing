using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using XamSample.DependencyServices;

[assembly: Xamarin.Forms.Dependency(typeof(XamSample.Droid.DependencyServices.FileHelperImpl))]
namespace XamSample.Droid.DependencyServices
{
    public class FileHelperImpl : IFileHelper
    {
        public Assembly GetAssemblyDetails()
        {
            return this.GetType().Assembly;
        }
    }
}