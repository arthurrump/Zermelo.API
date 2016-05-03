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
    /// Model for Appointments, as described at https://zermelo.atlassian.net/wiki/display/DEV/Appointment
    /// </summary>
    public class Appointment
    {
        /// <summary>
        /// The possible types of appointments
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
        /// The id of this version of the appointment.
        /// </summary>
        [JsonProperty("id")]
        public long Id { get; set; }

        /// <summary>
        /// The id of this instance of the appointment. Every instance has one or more versions.
        /// </summary>
        [JsonProperty("appointmentInstance")]
        public long InstanceId { get; set; }

        /// <summary>
        /// The start time of the appointment.
        /// </summary>
        [JsonProperty("start")]
        [JsonConverter(typeof(UnixTimeToDateTimeOffsetJsonConverter))]
        public DateTimeOffset Start { get; set; }

        /// <summary>
        /// The end time of the appointment (the first moment the appointment is no longer taking place).
        /// </summary>
        [JsonProperty("end")]
        [JsonConverter(typeof(UnixTimeToDateTimeOffsetJsonConverter))]
        public DateTimeOffset End { get; set; }

        /// <summary>
        /// Timeslot during which the appointment starts.
        /// </summary>
        [JsonProperty("startTimeSlot")]
        public int? StartTimeSlot { get; set; }

        /// <summary>
        /// Timeslot during which the appointment ends.
        /// </summary>
        [JsonProperty("endTimeSlot")]
        public int? EndTimeSlot { get; set; }

        /// <summary>
        /// List of subjects.
        /// </summary>
        [JsonProperty("subjects")]
        public IEnumerable<string> Subjects { get; set; }

        /// <summary>
        /// The type of appointment.
        /// </summary>
        [JsonProperty("type")]
        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public AppointmentType Type { get; set; }

        /// <summary>
        /// A remark for the appointment.
        /// </summary>
        [JsonProperty("remark")]
        public string Remark { get; set; }

        /// <summary>
        /// The locations (classrooms) where the appointment takes place.
        /// </summary>
        [JsonProperty("locations")]
        public IEnumerable<string> Locations { get; set; }

        /// <summary>
        /// The teachers participating in the appointment.
        /// </summary>
        [JsonProperty("teachers")]
        public IEnumerable<string> Teachers { get; set; }

        /// <summary>
        /// The groups of students participating in the appointment.
        /// </summary>
        [JsonProperty("groups")]
        public IEnumerable<string> Groups { get; set; }

        /// <summary>
        /// The date this version of the appointment was created.
        /// </summary>
        [JsonProperty("created")]
        [JsonConverter(typeof(UnixTimeToDateTimeOffsetJsonConverter))]
        public DateTimeOffset Created { get; set; }

        /// <summary>
        /// The date this version of the appointment was last modified.
        /// </summary>
        [JsonProperty("lastModified")]
        [JsonConverter(typeof(UnixTimeToDateTimeOffsetJsonConverter))]
        public DateTimeOffset LastModified { get; set; }

        /// <summary>
        /// True if this appointment is part of the most up-to-date schedule. Only one version of an instance can be valid; a valid version can still be canceled.
        /// </summary>
        [JsonProperty("valid")]
        public bool Valid { get; set; }

        /// <summary>
        /// This appointment should not be shown to the user if this is true. An hidden appointment cannot be valid.
        /// </summary>
        [JsonProperty("hidden")]
        public bool Hidden { get; set; }

        /// <summary>
        /// True when this version is the first non-hidden one.
        /// </summary>
        [JsonProperty("base")]
        public bool? Base { get; set; }

        /// <summary>
        /// True if the appointment is cancelled and no attendance is required.
        /// </summary>
        [JsonProperty("cancelled")]
        public bool Cancelled { get; set; }

        /// <summary>
        /// True if the appointment is modified.
        /// </summary>
        [JsonProperty("modified")]
        public bool Modified { get; set; }

        /// <summary>
        /// True if the time or location of the appointment is changed.
        /// </summary>
        [JsonProperty("moved")]
        public bool Moved { get; set; }

        /// <summary>
        /// True if the appointment was not originally scheduled.
        /// </summary>
        [JsonProperty("new")]
        public bool New { get; set; }

        /// <summary>
        /// Textual description of the change.
        /// </summary>
        [JsonProperty("changeDescription")]
        public string ChangeDescription { get; set; }

        /// <summary>
        /// The id of the branch of the school this appointment belongs to.
        /// </summary>
        [JsonProperty("branchOfSchool")]
        public long? BranchId { get; set; }

        /// <summary>
        /// The branch of the school this appointment belongs to.
        /// </summary>
        [JsonProperty("branch")]
        public string Branch { get; set; }
    }
}
