using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    class AppointmentsEndpoint : EndpointBase
    {
        private const string _endpoint = "appointments";

        internal AppointmentsEndpoint(IAuthentication auth, IUrlBuilder urlBuilder, IHttpService httpService, IJsonService jsonService)
            : base(auth, urlBuilder, httpService, jsonService)
        {
        }

        /// <summary>
        /// Get all appointments that start between the specified start and end points.
        /// </summary>
        /// <param name="start">The date from which to get appointments.</param>
        /// <param name="end">The date until which to get appointments.</param>
        /// <param name="user">The user to get appointments for. Defaults to <c>"~me"</c> to get appointments for the current user.</param>
        /// <param name="fields">
        /// The fields (in original json names) to get. Defaults to <c>null</c>, which gets the server defaults.
        /// An empty list will also result in the server defaults.
        /// </param>
        /// <returns>List of appointments.</returns>
        public async Task<IEnumerable<Appointment>> GetByDateAsync(DateTimeOffset start, DateTimeOffset end, string user = "~me", List<string> fields = null)
        {
            if (start <= end)
                throw new ArgumentOutOfRangeException(nameof(end), end,
                    $"The value of the {nameof(end)} parameter should be later in time " + 
                    $"than the value of the {nameof(start)} parameter (value: {start.ToString()}).");

            Dictionary<string, string> urlOptions = new Dictionary<string, string>
            {
                { "user", user },
                { "start", UnixTimeHelpers.ToUnixTimeSeconds(start.ToUniversalTime()).ToString() },
                { "end", UnixTimeHelpers.ToUnixTimeSeconds(end.ToUniversalTime()).ToString() }
            };

            return await GetByCustomUrlOptionsAsync(urlOptions, fields);
        }

        /// <summary>
        /// Get a specific appointment by it's id.
        /// </summary>
        /// <param name="id">The id of the appointment to get.</param>
        /// <param name="fields">
        /// The fields (in original json names) to get. Defaults to <c>null</c>, which gets the server defaults.
        /// An empty list will also result in the server defaults.
        /// </param>
        /// <returns>The requested appointment, or, if it's not found, null.</returns>
        public async Task<Appointment> GetSingleByIdAsync(long id, List<string> fields = null)
        {
            Dictionary<string, string> urlOptions = new Dictionary<string, string>
            {
                { "id", id.ToString() }
            };

            IEnumerable<Appointment> result = await GetByCustomUrlOptionsAsync(urlOptions, fields);

            if (result.Count() < 1)
                return null;

            return result.SingleOrDefault();
        }

        /// <summary>
        /// Get all versions of an appointment instance by it's <c>InstanceId</c>.
        /// </summary>
        /// <param name="instanceId">The id of the appointment instance.</param>
        /// <param name="fields">
        /// The fields (in original json names) to get. Defaults to <c>null</c>, which gets the server defaults.
        /// An empty list will also result in the server defaults.
        /// </param>
        /// <returns>All versions of an appointment instance.</returns>
        public async Task<IEnumerable<Appointment>> GetAllVersionsByInstanceIdAsync(long instanceId, List<string> fields = null)
        {
            Dictionary<string, string> urlOptions = new Dictionary<string, string>
            {
                { "appointmentInstance", instanceId.ToString() }
            };

            return await GetByCustomUrlOptionsAsync(urlOptions, fields);
        }

        /// <summary>
        /// Get appointments by a custom query.
        /// </summary>
        /// <param name="urlOptions">The options you want to be in the url.</param>
        /// <param name="fields">
        /// The fields (in original json names) to get. Defaults to <c>null</c>, which gets the server defaults.
        /// An empty list will also result in the server defaults.
        /// </param>
        /// <returns>The requested appointments.</returns>
        public async Task<IEnumerable<Appointment>> GetByCustomUrlOptionsAsync(Dictionary<string, string> urlOptions, List<string> fields = null)
        {
            return await GetByCustomUrlOptionsAsync<Appointment>(_endpoint, urlOptions, fields);
        }
    }
}
