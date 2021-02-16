using NLog;
using NLog.Config;
using System;
using System.IO;
using Xamarin.Forms;
using XamSample.Contracts.Services;
using XamSample.DependencyServices;

namespace XamSample.Services
{
    /// <summary>
    /// Defines the <see cref="LogService" />.
    /// </summary>
    public class LogService : ILogService
    {
        #region Fields

        /// <summary>
        /// Defines the logger.
        /// </summary>
        private Logger logger;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="LogService"/> class.
        /// </summary>
        public LogService()
        {
            //getfile();
            Initialize();
        }

        #endregion

        #region Methods

        /// <summary>
        /// The getfile.
        /// </summary>
        public string GetLogMessage()
        {
            string folder;
            folder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string logFolder = System.IO.Path.Combine(folder, "logs");
            if (System.IO.Directory.Exists(logFolder))
            {
                var filepath = Path.Combine(logFolder,"logfile.txt");
                if (File.Exists(filepath))
                {
                    var text = File.ReadAllText(filepath);
                    return text;
                }
            }
            return string.Empty;
        }

        /// <summary>
        /// The Initialize.
        /// </summary>
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

        /// <summary>
        /// The LogDebug.
        /// </summary>
        /// <param name="message">The message<see cref="string"/>.</param>
        public void LogDebug(string message)
        {
            this.logger.Info(message);
        }

        /// <summary>
        /// The LogError.
        /// </summary>
        /// <param name="message">The message<see cref="string"/>.</param>
        public void LogError(string message)
        {
            this.logger.Error(message);
        }

        /// <summary>
        /// The LogFatal.
        /// </summary>
        /// <param name="message">The message<see cref="string"/>.</param>
        public void LogFatal(string message)
        {
            this.logger.Fatal(message);
        }

        /// <summary>
        /// The LogInfo.
        /// </summary>
        /// <param name="message">The message<see cref="string"/>.</param>
        public void LogInfo(string message)
        {
            this.logger.Info(message);
        }

        /// <summary>
        /// The LogWarning.
        /// </summary>
        /// <param name="message">The message<see cref="string"/>.</param>
        public void LogWarning(string message)
        {
            this.logger.Warn(message);
        }

        #endregion
    }
}
