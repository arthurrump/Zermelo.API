using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zermelo.API.Interfaces;
using Zermelo.API.Models;
using Zermelo.API.Services.Interfaces;
using Zermelo.API.Helpers;
using Zermelo.API.Exceptions;

namespace Zermelo.API.Endpoints
{
    /// <summary>
    /// This endpoint can give you information about Users.
    /// </summary>
    /// <remarks>
    /// For more information about this endpoint, visit the official documentation
    /// [over here](https://zermelo.atlassian.net/wiki/display/DEV/User).
    /// </remarks>
    /// <seealso cref="User"/>
    /// <seealso cref="ZermeloConnection"/>
    public class UsersEndpoint : EndpointBase
    {
        private const string _endpoint = "users";

        internal UsersEndpoint(IAuthentication auth, IUrlBuilder urlBuilder, IHttpService httpService, IJsonService jsonService)
            : base(auth, urlBuilder, httpService, jsonService)
        {

        }

        /// <summary>
        /// Get the current authenticated user.
        /// </summary>
        /// <param name="fields">
        /// The fields (as json keys) to get. Defaults to <c>null</c>, 
        /// which will result in all fields listed in <see cref="User.Fields"/>.
        /// </param>
        /// <returns>The current authenticated user.</returns>
        public async Task<User> GetCurrentUserAsync(IList<string> fields = null)
        {
            return await GetByCodeAsync("~me", fields);
        }

        /// <summary>
        /// Get a user by it's code (a student number or teacher abbreviation).
        /// </summary>
        /// <remarks>
        /// When authenticated via an authorization code (which is the only way that's currently supported), you're not allowed
        /// to request the FirstName property of a teacher, resulting in a HTTP 403 error. You should use the <paramref name="fields"/>
        /// parameter to list the properties you want to get. Getting the FirstName of students is allowed.
        /// </remarks>
        /// <param name="code">The code (a student number or teacher abbreviation) of the user.</param>
        /// <param name="fields">
        /// The fields (as json keys) to get. Defaults to <c>null</c>, 
        /// which will result in all fields listed in <see cref="User.Fields"/>.
        /// </param>
        /// <returns>The requested user or, if the user's not found, <c>null</c>.</returns>
        public async Task<User> GetByCodeAsync(string code, IList<string> fields = null)
        {
             IEnumerable<User> result = await GetByCustomUrlOptionsAsync<User>($"{_endpoint}/{code.ToLowerInvariant()}", null, fields ?? User.Fields);

            if (result.Count() < 1)
                return null;

            return result.SingleOrDefault();
        }

        /// <summary>
        /// Get a list of all users.
        /// </summary>
        /// <remarks>
        /// When authenticated via an authorization code (which is the only way that's currently supported), you're not allowed
        /// to request the FirstName property, resulting in a HTTP 403 error. By default this property is excluded from the request.
        /// </remarks>
        /// <param name="fields">
        /// The fields (as json keys) to get. Defaults to <c>null</c>, 
        /// which will result in all fields listed in <see cref="User.Fields"/>, except for <c>firstName</c>.
        /// </param>
        /// <returns>A list of all users.</returns>
        public async Task<IEnumerable<User>> GetAllAsync(IList<string> fields = null)
        {
            if (fields == null)
            {
                fields = User.Fields.ToList();
                fields.Remove("firstName");
            }

            return await GetByCustomUrlOptionsAsync(null, fields);
        }

        /// <summary>
        /// Get users by a custom query.
        /// </summary>
        /// <param name="urlOptions">The options you want to be in the url.</param>
        /// <param name="fields">
        /// The fields (as json keys) to get. Defaults to <c>null</c>, 
        /// which will result in all fields listed in <see cref="User.Fields"/>.
        /// </param>
        /// <returns>The requested users.</returns>
        public async Task<IEnumerable<User>> GetByCustomUrlOptionsAsync(Dictionary<string, string> urlOptions, IList<string> fields = null)
        {
            return await GetByCustomUrlOptionsAsync<User>(_endpoint, urlOptions, fields ?? User.Fields);
        }
    }
}
