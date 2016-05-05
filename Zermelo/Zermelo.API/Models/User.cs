using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zermelo.API.Models
{
    /// <summary>
    /// Model for Users, as described at https://zermelo.atlassian.net/wiki/display/DEV/User
    /// </summary>
    public class User
    {
        /// <summary>
        /// The identifier for a user. Usually a student id or abbreviation.
        /// </summary>
        [JsonProperty("code")]
        public string Code { get; set; }

        /// <summary>
        /// The roles that have been assigned to this user.
        /// </summary>
        [JsonProperty("roles")]
        public IEnumerable<string> Roles { get; set; }

        /// <summary>
        /// The first name of a user.
        /// </summary>
        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        /// <summary>
        /// Dutch: "tussenvoegsel"
        /// </summary>
        [JsonProperty("prefix")]
        public string Prefix { get; set; }

        /// <summary>
        /// The last name of the user.
        /// </summary>
        [JsonProperty("lastName")]
        public string LastName { get; set; }

        /// <summary>
        /// The full name of the user.
        /// </summary>
        public string FullName
        {
            get
            {
                if (String.IsNullOrWhiteSpace(Prefix))
                    return $"{FirstName} {LastName}";
                else
                    return $"{FirstName} {Prefix} {LastName}";
            }
        }
    }
}
