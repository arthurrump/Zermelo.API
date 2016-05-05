﻿using System;
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
        /// The fields (in original json names) to get. Defaults to <c>null</c>, which gets the server defaults.
        /// An empty list will also result in the server defaults.
        /// </param>
        /// <returns>The current authenticated user.</returns>
        public async Task<User> GetCurrentUserAsync(List<string> fields = null)
        {
            return await GetByCodeAsync("~me", fields);
        }

        /// <summary>
        /// Get a user by it's code (a student number or teacher abbreviation).
        /// </summary>
        /// <param name="code">The code (a student number or teacher abbreviation) of the user.</param>
        /// <param name="fields">
        /// The fields (in original json names) to get. Defaults to <c>null</c>, which gets the server defaults.
        /// An empty list will also result in the server defaults.
        /// </param>
        /// <returns>The requested user or, if the user's not found, null.</returns>
        public async Task<User> GetByCodeAsync(string code, List<string> fields = null)
        {
            IEnumerable<User> result = await GetByCustomUrlOptionsAsync<User>($"{_endpoint}/{code}", null, fields);

            if (result.Count() < 1)
                return null;

            return result.SingleOrDefault();
        }

        /// <summary>
        /// Get a list of all users.
        /// </summary>
        /// <param name="fields">
        /// The fields (in original json names) to get. Defaults to <c>null</c>, which gets the server defaults.
        /// An empty list will also result in the server defaults.
        /// </param>
        /// <returns>A list of all users.</returns>
        public async Task<IEnumerable<User>> GetAllAsync(List<string> fields = null)
        {
            return await GetByCustomUrlOptionsAsync(null, fields);
        }

        /// <summary>
        /// Get users by a custom query.
        /// </summary>
        /// <param name="urlOptions">The options you want to be in the url.</param>
        /// <param name="fields">
        /// The fields (in original json names) to get. Defaults to <c>null</c>, which gets the server defaults.
        /// An empty list will also result in the server defaults.
        /// </param>
        /// <returns>The requested users.</returns>
        public async Task<IEnumerable<User>> GetByCustomUrlOptionsAsync(Dictionary<string, string> urlOptions, List<string> fields = null)
        {
            return await GetByCustomUrlOptionsAsync<User>(_endpoint, urlOptions, fields);
        }
    }
}
