namespace XamSample.Contracts.Services
{
    #region Interfaces

    /// <summary>
    /// Defines the <see cref="ILogService" />.
    /// </summary>
    public interface ILogService
    {
        #region Methods

        /// <summary>
        /// The Initialize.
        /// </summary>
        void Initialize();

        /// <summary>
        /// The LogDebug.
        /// </summary>
        /// <param name="message">The message<see cref="string"/>.</param>
        void LogDebug(string message);

        /// <summary>
        /// The LogError.
        /// </summary>
        /// <param name="message">The message<see cref="string"/>.</param>
        void LogError(string message);

        /// <summary>
        /// The LogFatal.
        /// </summary>
        /// <param name="message">The message<see cref="string"/>.</param>
        void LogFatal(string message);

        /// <summary>
        /// The LogInfo.
        /// </summary>
        /// <param name="message">The message<see cref="string"/>.</param>
        void LogInfo(string message);

        /// <summary>
        /// The LogWarning.
        /// </summary>
        /// <param name="message">The message<see cref="string"/>.</param>
        void LogWarning(string message);

        #endregion
    }

    #endregion
}
