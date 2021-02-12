using System.Threading.Tasks;

namespace XamSample.Contracts
{
    #region Interfaces

    /// <summary>
    /// Defines the <see cref="ILoginService" />.
    /// </summary>
    public interface ILoginService
    {
        #region Methods

        /// <summary>
        /// The Login.
        /// </summary>
        /// <param name="username">The username<see cref="string"/>.</param>
        /// <param name="password">The password<see cref="string"/>.</param>
        /// <returns>The <see cref="Task{bool}"/>.</returns>
        Task<bool> Login(string username, string password);

        /// <summary>
        /// The Register.
        /// </summary>
        /// <param name="username">The username<see cref="string"/>.</param>
        /// <param name="password">The password<see cref="string"/>.</param>
        /// <returns>The <see cref="Task{bool}"/>.</returns>
        Task<bool> Register(string username, string password);

        /// <summary>
        /// The RegisterDefaultUser.
        /// </summary>
        /// <returns>The <see cref="Task"/>.</returns>
        Task RegisterDefaultUser();

        #endregion
    }

    #endregion
}
