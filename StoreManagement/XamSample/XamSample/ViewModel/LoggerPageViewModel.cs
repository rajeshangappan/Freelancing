using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using XamSample.Contracts.Services;
using XamSample.Services;

namespace XamSample.ViewModel
{
    public class LoggerPageViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private string _logmessage;
        public string LogMessage
        {
            get
            {
                return _logmessage;
            }
            set
            {
                _logmessage = value;
                OnPropertyChanged(nameof(LogMessage));
            }
        }

        /// <summary>
        /// Gets the OnAppearingCommand.
        /// </summary>
        public ICommand OnAppearingCommand => new Command(OnAppearing);

        public ICommand SendMailCommand => new Command(async () => await OnSendMail());

        public event PropertyChangedEventHandler PropertyChanged;

        private async Task OnSendMail()
        {
            await SendEmail("Log message", LogMessage, new List<string>());
        }

        public async Task SendEmail(string subject, string body, List<string> recipients)
        {
            try
            {
                var fn = "Log.txt";
                var file = Path.Combine(FileSystem.CacheDirectory, fn);
                File.WriteAllText(file, LogMessage);
                var message = new EmailMessage
                {
                    Subject = subject + DateTime.Now.ToString("MM’-‘dd’-‘yyyy’T’HH’:’mm’:’ss"),
                    Body = body,
                    To = recipients,
                    
                    //Cc = ccRecipients,
                    //Bcc = bccRecipients
                };
                message.Attachments.Add(new EmailAttachment(file));
                await Email.ComposeAsync(message);
            }
            catch (FeatureNotSupportedException fbsEx)
            {
                // Email is not supported on this device
            }
            catch (Exception ex)
            {
                // Some other exception occurred
            }
        }

        public LoggerPageViewModel(NavigationService navigationService, ILogService logService) : base(logService)
        {

        }

        /// <summary>
        /// The OnAppearing.
        /// </summary>
        /// <returns>The <see cref="Task"/>.</returns>
        private void OnAppearing()
        {
            LogMessage = LogService.GetLogMessage();
        }

        protected void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
