using XamSample.Contracts.Services;

namespace XamSample.ViewModel
{
    /// <summary>
    /// Defines the <see cref="ViewModelBase" />.
    /// </summary>
    public class ViewModelBase
    {
        #region Fields

        /// <summary>
        /// Defines the LogService.
        /// </summary>
        protected ILogService LogService;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModelBase"/> class.
        /// </summary>
        /// <param name="logService">The logService<see cref="ILogService"/>.</param>
        public ViewModelBase(ILogService logService)
        {
            LogService = logService;
        }

        #endregion
    }
}
