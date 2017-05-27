using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zermelo.API.Models
{
    /// <summary>
    /// Model for Users, the actual persons in the school: students, teachers, and sometimes even parents.
    /// </summary>
    /// <remarks>
    /// For more information about users, visit the official documentation
    /// [here](https://zermelo.atlassian.net/wiki/display/DEV/User).
    /// </remarks>
    /// <seealso cref="API.Endpoints.UsersEndpoint"/>
    public class User
    {
        /// <summary>
        /// A list of all JSON keys implemented in this model that can be returned by the API. 
        /// This is the list that will be passed to the API by default in the related methods, unless stated otherwise.
        /// </summary>
        public static IList<string> Fields => new string[] {
            "code", "roles", "firstName", "prefix", "lastName"
        };

        /// <summary>
        /// The identifier for a user. Usually a student id or abbreviation. JSON Key: <c>code</c>
        /// </summary>
        [JsonProperty("code")]
        public string Code { get; internal set; }

        /// <summary>
        /// The roles that have been assigned to this user. JSON Key: <c>roles</c>
        /// </summary>
        [JsonProperty("roles")]
        public IEnumerable<string> Roles { get; internal set; }

        /// <summary>
        /// The first name of a user. JSON Key: <c>firstName</c>
        /// </summary>
        [JsonProperty("firstName")]
        public string FirstName { get; internal set; }

        /// <summary>
        /// Dutch: "tussenvoegsel".  JSON Key: <c>prefix</c>
        /// </summary>
        [JsonProperty("prefix")]
        public string Prefix { get; internal set; }

        /// <summary>
        /// The last name of the user. JSON Key: <c>lastName</c>
        /// </summary>
        [JsonProperty("lastName")]
        public string LastName { get; internal set; }

        /// <summary>
        /// The full name of the user. Added for convenience, not in the JSON.
        /// </summary>
        public string FullName
        {
            get
            {
                if (String.IsNullOrWhiteSpace(LastName))
                    if (String.IsNullOrWhiteSpace(FirstName))
                        return null;
                    else
                        return FirstName;
                else
                    if (String.IsNullOrWhiteSpace(Prefix))
                        if (String.IsNullOrWhiteSpace(FirstName))
                            return LastName;
                        else
                            return $"{FirstName} {LastName}";
                    else
                        if (String.IsNullOrWhiteSpace(FirstName))
                            return $"{Prefix} {LastName}";
                        else
                            return $"{FirstName} {Prefix} {LastName}";
            }
        }
    }
}
