using NLog;
using NLog.Config;
using NLog.Targets;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml;
using Xamarin.Forms;
using XamSample.Contracts.Services;
using XamSample.DependencyServices;

namespace XamSample.Services
{
    public class LogService : ILogService
    {
        private Logger logger;

        public LogService()
        {
            //getfile();
            Initialize();
        }

        public void Initialize()
        {
            var assembly = DependencyService.Get<IFileHelper>().GetAssemblyDetails();

            var files = assembly.GetManifestResourceNames();

            Stream stream = assembly.GetManifestResourceStream(files[0]);
            if (stream == null)
                throw new Exception($"The resource was not loaded properly.");
            LogManager.Configuration = new XmlLoggingConfiguration(System.Xml.XmlReader.Create(stream), null);
            LogManager.Configuration.Variables["mydir"] = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            this.logger = LogManager.GetCurrentClassLogger();
        }

        public void LogDebug(string message)
        {
            this.logger.Info(message);
        }

        public void LogError(string message)
        {
            this.logger.Error(message);
        }

        public void LogFatal(string message)
        {
            this.logger.Fatal(message);
        }

        public void LogInfo(string message)
        {
            this.logger.Info(message);
        }

        public void LogWarning(string message)
        {
            this.logger.Warn(message);
        }


        public void getfile()
        {
            string folder;
            folder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string logFolder = System.IO.Path.Combine(folder, "logs");
            if (System.IO.Directory.Exists(logFolder))
            {
                var files = System.IO.Directory.GetFiles(logFolder);

                foreach (var t in files)
                {
                    string ppp = logFolder+"\\"+t;
                    var text = File.ReadAllText(ppp);
                }
            }
        }
    }
}
