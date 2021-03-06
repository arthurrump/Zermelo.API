﻿using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Zermelo.API.Models
{
    /// <summary>
    /// Model for locations, which are classrooms and other locations in a school.
    /// </summary>
    /// <seealso cref="Endpoints.LocationsEndpoint"/>
    public class Location
    {
        /// <summary>
        /// A list of all JSON keys implemented in this model that can be returned by the API. 
        /// This is the list that will be passed to the API by default in the related methods, unless stated otherwise.
        /// </summary>
        public static IList<string> Fields => new string[] {
            "id", "name", "parentteachernightCapacity", "courseCapacity", "branchOfSchool", "secondaryBranches"
        };

        /// <summary>
        /// The id of a location. JSON Key: <c>id</c>
        /// </summary>
        [JsonProperty("id")]
        public long? Id { get; internal set; }

        /// <summary>
        /// The name a location is known by to users. JSON Key: <c>name</c>
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; internal set; }

        /// <summary>
        /// Capacity for parent-teacher nights. JSON Key: <c>parentteachernightCapacity</c>
        /// </summary>
        [JsonProperty("parentteachernightCapacity")]
        public long? ParentteachernightCapacity { get; internal set; }

        /// <summary>
        /// Capacity during a course. JSON Key: <c>courseCapacity</c>
        /// </summary>
        [JsonProperty("courseCapacity")]
        public long? CourseCapacity { get; internal set; }

        /// <summary>
        /// The id of the main schoolbranch this location belongs to. JSON Key: <c>branchOfSchool</c>
        /// </summary>
        [JsonProperty("branchOfSchool")]
        public long? BranchId { get; internal set; }

        /// <summary>
        /// The ids of other schoolbranches this location belongs to. JSON Key: <c>secondaryBranches</c>
        /// </summary>
        [JsonProperty("secondaryBranches")]
        public IList<long> SecondaryBranches { get; internal set; }
    }

}
