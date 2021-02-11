using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace XamSample.Contracts.Services
{
    public interface ILogService
    {
        void Initialize();

        void LogDebug(string message);

        void LogError(string message);

        void LogFatal(string message);

        void LogInfo(string message);

        void LogWarning(string message);
    }
}
