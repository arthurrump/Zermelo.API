using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Zermelo.API.Models
{
    /// <summary>
    /// Model for groups of students.
    /// </summary>
    /// <seealso cref="Endpoints.GroupsEndpoint"/>
    public class Group
    {
        // <summary>
        /// A list of all JSON keys implemented in this model that can be returned by the API. 
        /// This is the list that will be passed to the API by default in the related methods, unless stated otherwise.
        /// </summary>
        public static IList<string> Fields => new string[] {
            "id", "departmentOfBranch", "name", "isMainGroup", "isMentorGroup", "extendedName"
        };

        /// <summary>
        /// The id of the group. JSON Key: <c>id</c>
        /// </summary>
        [JsonProperty("id")]
        public long? Id { get; internal set; }

        /// <summary>
        /// The department the group belongs to. JSON Key: <c>departmentOfBranch</c>
        /// </summary>
        [JsonProperty("departmentOfBranch")]
        public long? DepartmentId { get; internal set; }

        /// <summary>
        /// The name the group is known by to users. JSON Key: <c>name</c>
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; internal set; }

        /// <summary>
        /// Indicates if the group is a main group (Dutch: stamklas). <c>true</c> indicates a main group, 
        /// <c>false</c> a subject specific group. JSON Key: <c>isMainGroup</c>
        /// </summary>
        [JsonProperty("isMainGroup")]
        public bool? IsMainGroup { get; internal set; }

        /// <summary>
        /// Indicates if the group has a mentor. JSON Key: <c>isMentorGroup</c>
        /// </summary>
        [JsonProperty("isMentorGroup")]
        public bool? IsMentorGroup { get; internal set; }

        /// <summary>
        /// A longer version of the name, also indicating the department. JSON Key: <c>extendedName</c>
        /// </summary>
        [JsonProperty("extendedName")]
        public string ExtendedName { get; internal set; }
    }
}
