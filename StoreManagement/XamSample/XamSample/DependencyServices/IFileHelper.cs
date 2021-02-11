using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace XamSample.DependencyServices
{
    public interface IFileHelper
    {
        Assembly GetAssemblyDetails();
    }
}
