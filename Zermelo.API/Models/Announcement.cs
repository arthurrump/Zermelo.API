﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zermelo.API.Helpers;

namespace Zermelo.API.Models
{
    /// <summary>
    /// Model for Announcements, messages that don't map to a single appointment. Mostly used for global schedule changes.
    /// </summary>
    /// <remarks>
    /// Take a look at the &lt;a href="https://zermelo.atlassian.net/wiki/display/DEV/Announcement"&gt;official documentation&lt;/a&gt; 
    /// for more information about Announcements.
    /// </remarks>
    /// <seealso cref="API.Endpoints.AnnouncementsEndpoint"/>
    public class Announcement
    {
        /// <summary>
        /// The id of the announcement. JSON Key: <c>id</c>
        /// </summary>
        [JsonProperty("id")]
        public long? Id { get; internal set; }

        /// <summary>
        /// The date from which the announcement should be shown. JSON Key: <c>start</c>
        /// </summary>
        [JsonProperty("start")]
        [JsonConverter(typeof(UnixTimeToDateTimeOffsetJsonConverter))]
        public DateTimeOffset? Start { get; internal set; }

        /// <summary>
        /// The date until which the announcement should be shown. JSON Key: <c>end</c>
        /// </summary>
        [JsonProperty("end")]
        [JsonConverter(typeof(UnixTimeToDateTimeOffsetJsonConverter))]
        public DateTimeOffset? End { get; internal set; }

        /// <summary>
        /// The title of the announcement. JSON Key: <c>title</c>
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; internal set; }

        /// <summary>
        /// The detail text of the announcement.  JSON Key: <c>text</c>
        /// </summary>
        [JsonProperty("text")]
        public string Text { get; internal set; }
    }
}
