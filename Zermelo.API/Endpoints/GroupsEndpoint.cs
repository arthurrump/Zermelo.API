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
    /// This enpoint gives information abouts groups of students.
    /// </summary>
    /// <remarks>
    /// This endpoint isn't officially documented, but it's used in the official app to display the list of groups for which you can get a schedule.
    /// </remarks>
    /// <seealso cref="Group"/>
    /// <seealso cref="ZermeloConnection"/>
    public class GroupsEndpoint : EndpointBase
    {
        private const string _endpoint = "groupindepartments";

        internal GroupsEndpoint(IAuthentication auth, IUrlBuilder urlBuilder, IHttpService httpService, IJsonService jsonService) 
            : base(auth, urlBuilder, httpService, jsonService)
        {

        }

        /// <summary>
        /// Get all groups.
        /// </summary>
        /// <param name="fields">
        /// The fields (as json keys) to get. Defaults to <c>null</c>, 
        /// which will result in all fields listed in <see cref="Group.Fields"/>.
        /// </param>
        /// <returns>A list of all groups.</returns>
        public async Task<IEnumerable<Group>> GetAllAsync(IList<string> fields = null)
        {
            return await GetByCustomUrlOptionsAsync(new Dictionary<string, string>());
        }

        /// <summary>
        /// Get a single group by its id.
        /// </summary>
        /// <param name="id">The id of the requested group.</param>
        /// <param name="fields">
        /// The fields (as json keys) to get. Defaults to <c>null</c>, 
        /// which will result in all fields listed in <see cref="Group.Fields"/>.
        /// </param>
        /// <returns>The requested <see cref="Group"/>, or <c>null</c>, if it's not found.</returns>
        public async Task<Group> GetSingleById(long id, IList<string> fields = null)
        {
            Dictionary<string, string> urlOptions = new Dictionary<string, string>
            {
                { "id", id.ToString() }
            };

            IEnumerable<Group> result = await GetByCustomUrlOptionsAsync(urlOptions, fields);

            if (result.Count() < 1)
                return null;

            return result.SingleOrDefault();
        }

        /// <summary>
        /// Get groups by a custom query.
        /// </summary>
        /// <param name="urlOptions">The options you want to be in the url.</param>
        /// <param name="fields">
        /// The fields (as json keys) to get. Defaults to <c>null</c>, 
        /// which will result in all fields listed in <see cref="Group.Fields"/>.
        /// </param>
        /// <returns>The requested groups.</returns>
        public async Task<IEnumerable<Group>> GetByCustomUrlOptionsAsync(Dictionary<string, string> urlOptions, IList<string> fields = null)
        {
            return await GetByCustomUrlOptionsAsync<Group>(_endpoint, urlOptions, fields ?? Group.Fields);
        }
    }
}
