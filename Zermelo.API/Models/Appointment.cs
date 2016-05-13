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
    /// Model for Appointments, usually lessons, but including other activities, that make up the schedule.
    /// </summary>
    /// <remarks>
    /// To learn more about appointments, take a look at the official documentation
    /// &lt;a href="https://zermelo.atlassian.net/wiki/display/DEV/Appointment"&gt;over here&lt;/a&gt;.
    /// </remarks>
    /// <seealso cref="API.Endpoints.AppointmentsEndpoint"/>
    public class Appointment
    {
        /// <summary>
        /// The possible types of appointments.
        /// </summary>
        public enum AppointmentType
        {
            unknown,
            lesson,
            exam,
            activity,
            choice,
            talk,
            other
        }

        /// <summary>
        /// The id of this version of the appointment. JSON Key: <c>id</c>
        /// </summary>
        [JsonProperty("id")]
        public long? Id { get; internal set; }

        /// <summary>
        /// The id of this instance of the appointment. Every instance has one or more versions. JSON Key: <c>appointmentInstance</c>
        /// </summary>
        [JsonProperty("appointmentInstance")]
        public long? InstanceId { get; internal set; }

        /// <summary>
        /// The start time of the appointment. JSON Key: <c>start</c>
        /// </summary>
        [JsonProperty("start")]
        [JsonConverter(typeof(UnixTimeToDateTimeOffsetJsonConverter))]
        public DateTimeOffset? Start { get; internal set; }

        /// <summary>
        /// The end time of the appointment (the first moment the appointment is no longer taking place). JSON Key: <c>end</c>
        /// </summary>
        [JsonProperty("end")]
        [JsonConverter(typeof(UnixTimeToDateTimeOffsetJsonConverter))]
        public DateTimeOffset? End { get; internal set; }

        /// <summary>
        /// Timeslot during which the appointment starts. JSON Key: <c>startTimeSlot</c>
        /// </summary>
        [JsonProperty("startTimeSlot")]
        public int? StartTimeSlot { get; internal set; }

        /// <summary>
        /// Timeslot during which the appointment ends. JSON Key: <c>endTimeSlot</c>
        /// </summary>
        [JsonProperty("endTimeSlot")]
        public int? EndTimeSlot { get; internal set; }

        /// <summary>
        /// List of subjects. JSON Key: <c>subjects</c>
        /// </summary>
        [JsonProperty("subjects")]
        public IEnumerable<string> Subjects { get; internal set; }

        /// <summary>
        /// The type of appointment. JSON Key: <c>type</c>
        /// </summary>
        [JsonProperty("type")]
        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public AppointmentType? Type { get; internal set; }

        /// <summary>
        /// A remark for the appointment. JSON Key: <c>remark</c>
        /// </summary>
        [JsonProperty("remark")]
        public string Remark { get; internal set; }

        /// <summary>
        /// The locations (classrooms) where the appointment takes place. JSON Key: <c>locations</c>
        /// </summary>
        [JsonProperty("locations")]
        public IEnumerable<string> Locations { get; internal set; }

        /// <summary>
        /// The teachers participating in the appointment. JSON Key: <c>teachers</c>
        /// </summary>
        [JsonProperty("teachers")]
        public IEnumerable<string> Teachers { get; internal set; }

        /// <summary>
        /// The groups of students participating in the appointment. JSON Key: <c>groups</c>
        /// </summary>
        [JsonProperty("groups")]
        public IEnumerable<string> Groups { get; internal set; }

        /// <summary>
        /// The date this version of the appointment was created. JSON Key: <c>created</c>
        /// </summary>
        [JsonProperty("created")]
        [JsonConverter(typeof(UnixTimeToDateTimeOffsetJsonConverter))]
        public DateTimeOffset? Created { get; internal set; }

        /// <summary>
        /// The date this version of the appointment was last modified. JSON Key: <c>lastModified</c>
        /// </summary>
        [JsonProperty("lastModified")]
        [JsonConverter(typeof(UnixTimeToDateTimeOffsetJsonConverter))]
        public DateTimeOffset? LastModified { get; internal set; }

        /// <summary>
        /// True if this appointment is part of the most up-to-date schedule. 
        /// Only one version of an instance can be valid; a valid version can still be canceled. JSON Key: <c>valid</c>
        /// </summary>
        [JsonProperty("valid")]
        public bool? Valid { get; internal set; }

        /// <summary>
        /// This appointment should not be shown to the user if this is true. An hidden appointment cannot be valid. JSON Key: <c>hidden</c>
        /// </summary>
        [JsonProperty("hidden")]
        public bool? Hidden { get; internal set; }

        /// <summary>
        /// True when this version is the first non-hidden one. JSON Key: <c>base</c>
        /// </summary>
        [JsonProperty("base")]
        public bool? Base { get; internal set; }

        /// <summary>
        /// True if the appointment is cancelled and no attendance is required. JSON Key: <c>cancelled</c>
        /// </summary>
        [JsonProperty("cancelled")]
        public bool? Cancelled { get; internal set; }

        /// <summary>
        /// True if the appointment is modified. JSON Key: <c>modified</c>
        /// </summary>
        [JsonProperty("modified")]
        public bool? Modified { get; internal set; }

        /// <summary>
        /// True if the time or location of the appointment is changed. JSON Key: <c>moved</c>
        /// </summary>
        [JsonProperty("moved")]
        public bool? Moved { get; internal set; }

        /// <summary>
        /// True if the appointment was not originally scheduled. JSON Key: <c>new</c>
        /// </summary>
        [JsonProperty("new")]
        public bool? New { get; internal set; }

        /// <summary>
        /// Textual description of the change. JSON Key: <c>changeDescription</c>
        /// </summary>
        [JsonProperty("changeDescription")]
        public string ChangeDescription { get; internal set; }

        /// <summary>
        /// The id of the branch of the school this appointment belongs to. JSON Key: <c>branchOfSchool</c>
        /// </summary>
        [JsonProperty("branchOfSchool")]
        public long? BranchId { get; internal set; }

        /// <summary>
        /// The branch of the school this appointment belongs to. JSON Key: <c>branch</c>
        /// </summary>
        [JsonProperty("branch")]
        public string Branch { get; internal set; }
    }
}
