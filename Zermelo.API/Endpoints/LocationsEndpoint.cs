using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zermelo.API.Interfaces;
using Zermelo.API.Models;
using Zermelo.API.Services.Interfaces;

namespace Zermelo.API.Endpoints
{
    /// <summary>
    /// This endpoint gives you information about classrooms and other locations in a school.
    /// </summary>
    /// <remarks>
    /// This endpoint isn't officially documented, but it's used in the official app to display the list of locations for which you can get a schedule.
    /// </remarks>
    /// <seealso cref="Location"/>
    /// <seealso cref="ZermeloConnection"/>
    public class LocationsEndpoint : EndpointBase
    {
        private const string _endpoint = "locationofbranches";

        internal LocationsEndpoint(IAuthentication auth, IUrlBuilder urlBuilder, IHttpService httpService, IJsonService jsonService) 
            : base(auth, urlBuilder, httpService, jsonService)
        {

        }

        /// <summary>
        /// Get all locations.
        /// </summary>
        /// <param name="fields">
        /// The fields (as json keys) to get. Defaults to <c>null</c>, 
        /// which will result in all fields listed in <see cref="Location.Fields"/>.
        /// </param>
        /// <returns>A list of all locations.</returns>
        public async Task<IEnumerable<Location>> GetAllAsync(IList<string> fields = null)
        {
            return await GetByCustomUrlOptionsAsync(new Dictionary<string, string>());
        }

        /// <summary>
        /// Get a single location by its id.
        /// </summary>
        /// <param name="id">The id of the requested location.</param>
        /// <param name="fields">
        /// The fields (as json keys) to get. Defaults to <c>null</c>, 
        /// which will result in all fields listed in <see cref="Location.Fields"/>.
        /// </param>
        /// <returns>The requested <see cref="Location"/>, or <c>null</c>, if it's not found.</returns>
        public async Task<Location> GetSingleById(long id, IList<string> fields = null)
        {
            Dictionary<string, string> urlOptions = new Dictionary<string, string>
            {
                { "id", id.ToString() }
            };

            IEnumerable<Location> result = await GetByCustomUrlOptionsAsync(urlOptions, fields);

            if (result.Count() < 1)
                return null;

            return result.SingleOrDefault();
        }

        /// <summary>
        /// Get locations by a custom query.
        /// </summary>
        /// <param name="urlOptions">The options you want to be in the url.</param>
        /// <param name="fields">
        /// The fields (as json keys) to get. Defaults to <c>null</c>, 
        /// which will result in all fields listed in <see cref="Location.Fields"/>.
        /// </param>
        /// <returns>The requested locations.</returns>
        public async Task<IEnumerable<Location>> GetByCustomUrlOptionsAsync(Dictionary<string, string> urlOptions, IList<string> fields = null)
        {
            return await GetByCustomUrlOptionsAsync<Location>(_endpoint, urlOptions, fields ?? Location.Fields);
        }
    }
}
