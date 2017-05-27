using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Zermelo.API.Helpers;

namespace Zermelo.API.Models
{
    /// <summary>
    /// Information about a token, which is used in an <see cref="Authentication"/> object.
    /// </summary>
    /// <remarks>
    /// Official documentation can be found [here](https://zermelo.atlassian.net/wiki/display/DEV/Token)
    /// </remarks>
    /// <seealso cref="Endpoints.AuthenticationEndpoint.GetCurrentTokenAsync"/>
    public class Token
    {
        /// <summary>
        /// A list of all JSON keys implemented in this model that can be returned by the API. 
        /// This is the list that will be passed to the API by default in the related methods, unless stated otherwise.
        /// </summary>
        public static IList<string> Fields => new string[] {
            "token", "user", "created", "expires", "timeout", "comment"
        };

        /// <summary>
        /// The token string itself. JSON Key: <c>token</c>
        /// </summary>
        [JsonProperty("token")]
        public string TokenCode { get; internal set; }

        /// <summary>
        /// The owner of the token. JSON Key: <c>user</c>
        /// </summary>
        [JsonProperty("user")]
        public string User { get; internal set; }

        /// <summary>
        /// The moment the token was created. JSON Key: <c>created</c>
        /// </summary>
        [JsonProperty("created")]
        [JsonConverter(typeof(UnixTimeToDateTimeOffsetJsonConverter))]
        public DateTimeOffset? Created { get; internal set; }

        /// <summary>
        /// The moment the token will expire and won't be usable anymore. JSON Key: <c>expires</c>
        /// </summary>
        [JsonProperty("expires")]
        [JsonConverter(typeof(UnixTimeToDateTimeOffsetJsonConverter))]
        public DateTimeOffset? Expires { get; internal set; }

        /// <summary>
        /// The moment the token will expire due to inactivity. This moment will be pushed back further when the token is used. JSON Key: <c>timeout</c>
        /// </summary>
        [JsonProperty("timeout")]
        [JsonConverter(typeof(UnixTimeToDateTimeOffsetJsonConverter))]
        public DateTimeOffset? Timeout { get; internal set; }

        /// <summary>
        /// A comment on the token. JSON Key: <c>comment</c>
        /// </summary>
        [JsonProperty("comment")]
        public string Comment { get; internal set; }
    }
}
