using System;
using System.Threading.Tasks;

namespace Dort.Service
{
    public interface IAuthService
    {
        /// <summary>
        /// Attempt to authenticate an user using his email and password.
        /// If this data are right, then is returned a x-authorization token.
        /// </summary>
        /// <param name="email">User's email</param>
        /// <param name="password">User's password</param>
        /// <returns>x-athorization token</returns>
        Task Authenticate(string email, string password);
        /// <summary>
        /// Returns the expirations time of Auth token.
        /// </summary>
        /// <returns></returns>
        DateTime GetTokenExpirationTime();
    }
}
