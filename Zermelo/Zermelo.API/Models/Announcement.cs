using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zermelo.API.Helpers;

namespace Zermelo.API.Models
{
    /// <summary>
    /// Model for Announcements, as described at https://zermelo.atlassian.net/wiki/display/DEV/Announcement
    /// </summary>
    public class Announcement
    {
        /// <summary>
        /// The id of the announcement
        /// </summary>
        [JsonProperty("id")]
        public long? Id { get; set; }

        /// <summary>
        /// The date from which the announcement should be shown
        /// </summary>
        [JsonProperty("start")]
        [JsonConverter(typeof(UnixTimeToDateTimeOffsetJsonConverter))]
        public DateTimeOffset? Start { get; set; }

        /// <summary>
        /// The date until which the announcement should be shown
        /// </summary>
        [JsonProperty("end")]
        [JsonConverter(typeof(UnixTimeToDateTimeOffsetJsonConverter))]
        public DateTimeOffset? End { get; set; }

        /// <summary>
        /// The title of the announcement
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// The detail text of the announcement
        /// </summary>
        [JsonProperty("text")]
        public string Text { get; set; }
    }
}
