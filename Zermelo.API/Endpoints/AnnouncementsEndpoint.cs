using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zermelo.API.Exceptions;
using Zermelo.API.Helpers;
using Zermelo.API.Interfaces;
using Zermelo.API.Models;
using Zermelo.API.Services.Interfaces;

namespace Zermelo.API.Endpoints
{
    /// <summary>
    /// This endpoint can give you information about Announcements.
    /// </summary>
    /// <remarks>
    /// For more information about this endpoint, visit the
    /// [official documentation](https://zermelo.atlassian.net/wiki/display/DEV/Announcement).
    /// </remarks>
    /// <seealso cref="Announcement"/>
    /// <seealso cref="ZermeloConnection"/>
    public class AnnouncementsEndpoint : EndpointBase
    {
        private const string _endpoint = "announcements";

        private IEnumerable<Announcement> _cache = null;
        private DateTimeOffset _cacheMoment = new DateTimeOffset();
        private List<string> _cacheFields = null;

        internal AnnouncementsEndpoint(IAuthentication auth, IUrlBuilder urlBuilder, IHttpService httpService, IJsonService jsonService)
            : base(auth, urlBuilder, httpService, jsonService)
        {

        }

        /// <summary>
        /// Get all announcements that should be displayed at the current time.
        /// </summary>
        /// <param name="fields">
        /// The fields (as json keys) to get. Defaults to <c>null</c>, which results in the defaults of the Zermelo API.
        /// An empty list will also result in the defaults.
        /// </param>
        /// <returns>The current announcements.</returns>
        public async Task<IEnumerable<Announcement>> GetCurrentAsync(List<string> fields = null)
        {
            Dictionary<string, string> urlOptions = new Dictionary<string, string>
            {
                { "current", "true" }
            };

            return await GetByCustomUrlOptionsAsync(urlOptions, fields);
        }

        /// <summary>
        /// Get all announcements between the specified start and end points.
        /// </summary>
        /// <param name="start">The date from which to get announcements.</param>
        /// <param name="end">The date until which to get announcements.</param>
        /// <param name="user">The user to get announcements for. Defaults to <c>"~me"</c> to get announcements for the current user.</param>
        /// <param name="fields">
        /// The fields (as json keys) to get. Defaults to <c>null</c>, which results in the defaults of the Zermelo API.
        /// An empty list will also result in the defaults.
        /// </param>
        /// <returns>List of <see cref="Announcement"/> objects.</returns>
        public async Task<IEnumerable<Announcement>> GetByDateAsync(DateTimeOffset start, DateTimeOffset end, string user = "~me", List<string> fields = null)
        {
            if (start <= end)
                throw new ArgumentOutOfRangeException(nameof(end), end,
                    $"The value of the {nameof(end)} parameter should be later in time " +
                    $"than the value of the {nameof(start)} parameter (value: {start.ToString()}).");

            // This shouldn't be needed, but the Zermelo API thinks a bit strange about which announcements to return...
            if (_cache == null || DateTimeOffset.UtcNow.Subtract(_cacheMoment.ToUniversalTime()) > new TimeSpan(0, 15, 0) ||
                fields != _cacheFields)
            {
                _cache = await GetAllAsync(fields);
                _cacheFields = fields;
                _cacheMoment = DateTimeOffset.UtcNow;
            }

            List<Announcement> result = new List<Announcement>();
            foreach (Announcement a in _cache)
            {
                if ((a.Start > start && a.Start < end) ||
                    (a.End > start && a.End < end) ||
                    (a.Start < start && a.End > end))
                {
                    result.Add(a);
                }
            }

            return result;
        }

        /// <summary>
        /// Get a specific <see cref="Announcement"/> by it's id.
        /// </summary>
        /// <param name="id">The id of the announcement to get.</param>
        /// <param name="fields">
        /// The fields (as json keys) to get. Defaults to <c>null</c>, which results in the defaults of the Zermelo API.
        /// An empty list will also result in the defaults.
        /// </param>
        /// <returns>The requested <see cref="Announcement"/>, or, if it's not found, <c>null</c>.</returns>
        public async Task<Announcement> GetSingleByIdAsync(long id, List<string> fields = null)
        {
            Dictionary<string, string> urlOptions = new Dictionary<string, string>
            {
                { "id", id.ToString() }
            };

            IEnumerable<Announcement> result = await GetByCustomUrlOptionsAsync(urlOptions, fields);

            if (result.Count() < 1)
                return null;

            return result.SingleOrDefault();
        }

        /// <summary>
        /// Get all announcements.
        /// </summary>
        /// <param name="fields">
        /// The fields (as json keys) to get. Defaults to <c>null</c>, which results in the defaults of the Zermelo API.
        /// An empty list will also result in the defaults.
        /// </param>
        /// <returns>A list of all announcements.</returns>
        public async Task<IEnumerable<Announcement>> GetAllAsync(List<string> fields = null)
        {
            return await GetByCustomUrlOptionsAsync(null, fields);
        }

        /// <summary>
        /// Get announcements by a custom query.
        /// </summary>
        /// <param name="urlOptions">The options you want to be in the url.</param>
        /// <param name="fields">
        /// The fields (as json keys) to get. Defaults to <c>null</c>, which results in the defaults of the Zermelo API.
        /// An empty list will also result in the defaults.
        /// </param>
        /// <returns>The requested announcements.</returns>
        public async Task<IEnumerable<Announcement>> GetByCustomUrlOptionsAsync(Dictionary<string, string> urlOptions, List<string> fields = null)
        {
            return await GetByCustomUrlOptionsAsync<Announcement>(_endpoint, urlOptions, fields);
        }
    }
}
