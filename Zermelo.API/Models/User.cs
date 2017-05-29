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
            "code", "roles", "isStudent", "isEmployee", "isFamilyMember", "firstName", "prefix", "lastName", "isApplicationManager",
            "isSchoolScheduler", "isSchoolLeader", "isStudentAdministrator", "isBranchLeader", "isTeamLeader", "isSectionLeader",
            "isMentor", "isParentTeacherNightScheduler", "isDean", "archived", "hasPassword"
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
        /// Indicates if the user is a student. JSON Key: <c>isStudent</c>
        /// </summary>
        [JsonProperty("isStudent")]
        public bool? IsStudent { get; internal set; }

        /// <summary>
        /// Indicates if the user is a employee. JSON Key: <c>isEmployee</c>
        /// </summary>
        [JsonProperty("isEmployee")]
        public bool? IsEmployee { get; internal set; }

        /// <summary>
        /// JSON Key: <c>isFamilyMember</c>
        /// </summary>
        [JsonProperty("isFamilyMember")]
        public bool? IsFamilyMember { get; internal set; }

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

        /// <summary>
        /// JSON Key: <c>isApplicationManager</c>
        /// </summary>
        [JsonProperty("isApplicationManager")]
        public bool? IsApplicationManager { get; internal set; }

        /// <summary>
        /// JSON Key: <c>isSchoolScheduler</c>
        /// </summary>
        [JsonProperty("isSchoolScheduler")]
        public bool? IsSchoolScheduler { get; internal set; }

        /// <summary>
        /// JSON Key: <c>isSchoolLeader</c>
        /// </summary>
        [JsonProperty("isSchoolLeader")]
        public bool? IsSchoolLeader { get; internal set; }

        /// <summary>
        /// JSON Key: <c>isStudentAdministrator</c>
        /// </summary>
        [JsonProperty("isStudentAdministrator")]
        public bool? IsStudentAdministrator { get; internal set; }

        /// <summary>
        /// JSON Key: <c>isBranchLeader</c>
        /// </summary>
        [JsonProperty("isBranchLeader")]
        public bool? IsBranchLeader { get; internal set; }

        /// <summary>
        /// JSON Key: <c>isTeamLeader</c>
        /// </summary>
        [JsonProperty("isTeamLeader")]
        public bool? IsTeamLeader { get; internal set; }

        /// <summary>
        /// JSON Key: <c>isSectionLeader</c>
        /// </summary>
        [JsonProperty("isSectionLeader")]
        public bool? IsSectionLeader { get; internal set; }

        /// <summary>
        /// JSON Key: <c>isMentor</c>
        /// </summary>
        [JsonProperty("isMentor")]
        public bool? IsMentor { get; internal set; }

        /// <summary>
        /// JSON Key: <c>isParentTeacherNightScheduler</c>
        /// </summary>
        [JsonProperty("isParentTeacherNightScheduler")]
        public bool? IsParentTeacherNightScheduler { get; internal set; }

        /// <summary>
        /// JSON Key: <c>isDean</c>
        /// </summary>
        [JsonProperty("isDean")]
        public bool? IsDean { get; internal set; }

        /// <summary>
        /// JSON Key: <c>archived</c>
        /// </summary>
        [JsonProperty("archived")]
        public bool? Archived { get; internal set; }

        /// <summary>
        /// JSON Key: <c>hasPassword</c>
        /// </summary>
        [JsonProperty("hasPassword")]
        public bool? HasPassword { get; internal set; }
    }
}
