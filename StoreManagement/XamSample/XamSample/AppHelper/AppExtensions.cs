using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace XamSample.AppHelper
{
    public static class AppExtensions
    {
        public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> enumerable)
        {
            return new ObservableCollection<T>(enumerable);
        }
    }
}
