using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XamSample.AppHelper;
using XamSample.Contracts;
using XamSample.Models;

namespace XamSample.Implementations
{
    /// <summary>
    /// Defines the <see cref="LoginService" />.
    /// </summary>
    public class LoginService : ILoginService
    {
        #region PRIVATE_VARIABLES

        /// <summary>
        /// Defines the _apiRepository.
        /// </summary>
        private readonly IApiRepository _apiRepository;

        #endregion

        #region CONSTRUCTOR

        /// <summary>
        /// Initializes a new instance of the <see cref="LoginService"/> class.
        /// </summary>
        /// <param name="apiRepository">The apiRepository<see cref="IApiRepository"/>.</param>
        public LoginService(IApiRepository apiRepository)
        {
            _apiRepository = apiRepository;
        }

        #endregion

        #region PRIVATE_METHODS

        /// <summary>
        /// The TempUserCheck.
        /// </summary>
        /// <param name="username">The username<see cref="string"/>.</param>
        /// <param name="password">The password<see cref="string"/>.</param>
        /// <returns>The <see cref="Task{bool}"/>.</returns>
        private async Task<bool> TempUserCheck(string username, string password)
        {
            var usernames = await Xamarin.Essentials.SecureStorage.GetAsync("users");
            var passwords = await Xamarin.Essentials.SecureStorage.GetAsync("passwords");
            var usernameslst = usernames.Split(',');
            var passwordslst = passwords.Split(',');

            if (usernameslst.Contains(username) && passwordslst.Contains(password))
            {
                if (username.Contains("admin"))
                {
                    await Xamarin.Essentials.SecureStorage.SetAsync("role", "admin");
                }
                else
                {
                    await Xamarin.Essentials.SecureStorage.SetAsync("role", "user");
                }
                return true;
            }
            return false;
        }

        public async Task RegisterDefaultUser()
        {
            if (await Xamarin.Essentials.SecureStorage.GetAsync("users") == null)
                await Xamarin.Essentials.SecureStorage.SetAsync("users", "user1,admin1,admin2");
            if (await Xamarin.Essentials.SecureStorage.GetAsync("passwords") == null)
                await Xamarin.Essentials.SecureStorage.SetAsync("passwords", "test,test,test");
        }

        #endregion
        
        #region PUBLIC_METHODS

        /// <summary>
        /// The Login.
        /// </summary>
        /// <param name="username">The username<see cref="string"/>.</param>
        /// <param name="password">The password<see cref="string"/>.</param>
        /// <returns>The <see cref="Task{bool}"/>.</returns>
        public async Task<bool> Login(string username, string password)
        {
            var URI = AppConstants.LogInUrl;

            if (!AppConstants.UseLocal)
            {
                try
                {
                    var result = await _apiRepository.PostAsync<LoginResponse>(URI, new User { Username = username, Password = password });

                    if (result != null)
                    {
                        await Xamarin.Essentials.SecureStorage.SetAsync("username", username);
                        await Xamarin.Essentials.SecureStorage.SetAsync("password", password);
                        await Xamarin.Essentials.SecureStorage.SetAsync("role", result.User.Role);
                        Xamarin.Forms.Application.Current.Properties["token"] = result.Token;
                        return true;
                    }
                    else
                    {
                        return await TempUserCheck(username, password);
                        //check username and password for offline. If user available return true.
                    }
                }
                catch (Exception)
                {
                    // log exception
                    return await TempUserCheck(username, password);
                }
            }
            else
            {
                return await TempUserCheck(username, password);
            }
        }

        public async Task<bool> Register(string username, string password)
        {
            var URI = AppConstants.LogInUrl;

            if (!AppConstants.UseLocal)
            {
                try
                {
                    //need to implement the API
                }
                catch (Exception)
                {
                    // log exception                    
                }
                return true;
            }
            else
            {
                return await NewUserRegistration(username, password);
            }
        }

        private async Task<bool> NewUserRegistration(string username, string password)
        {
            var newusers = await Xamarin.Essentials.SecureStorage.GetAsync("users");
            
            if(newusers!=null && newusers.Contains(username))
            {
                return false;
            }
            else
            {
                newusers = newusers == null ? username : newusers + "," + username;
                await Xamarin.Essentials.SecureStorage.SetAsync("users", newusers);
            }

            var newpasswords = await Xamarin.Essentials.SecureStorage.GetAsync("passwords");
            newpasswords = newpasswords == null ? password : newpasswords + "," + password;
            await Xamarin.Essentials.SecureStorage.SetAsync("passwords", newpasswords);
            return true;
        }

        #endregion
    }
}
