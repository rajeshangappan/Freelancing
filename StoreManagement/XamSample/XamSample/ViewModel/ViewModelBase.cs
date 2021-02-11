using XamSample.Contracts.Services;

namespace XamSample.ViewModel
{
    /// <summary>
    /// Defines the <see cref="ViewModelBase" />.
    /// </summary>
    public class ViewModelBase
    {
        protected ILogService LogService;
        public ViewModelBase(ILogService logService)
        {
            LogService = logService;
        }
    }
}
