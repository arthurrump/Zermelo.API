using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Zermelo.API.Models;
using Zermelo.API.Helpers;
using Newtonsoft.Json;

namespace Zermelo.API.Tests.Models
{
    public class AppointmentTests
    {
        [Fact]
        public static void ShouldDeserializeFull()
        {
            string testData = "{\"id\":51562,\"appointmentInstance\":21412,\"start\":423642360,\"end\":436234523,\"startTimeSlot\":1,\"endTimeSlot\":1,\"subjects\":[\"ne\"],\"teachers\":[\"tea\"],\"groups\":[\"gro\"],\"locations\":[\"loc\"],\"type\":\"lesson\",\"remark\":\"Remark\",\"valid\":true,\"hidden\":false,\"base\":true,\"cancelled\":false,\"modified\":true,\"moved\":false,\"new\":false,\"changeDescription\":\"Description\",\"created\":413642360,\"lastModified\":413642360,\"branchOfSchool\":2,\"branch\":\"Branch\"}";
            Appointment expected = new Appointment
            {
                Id = 51562,
                InstanceId = 21412,
                Start = UnixTimeHelpers.FromUnixTimeSeconds(423642360),
                End = UnixTimeHelpers.FromUnixTimeSeconds(436234523),
                StartTimeSlot = 1,
                EndTimeSlot = 1,
                Subjects = new List<string> { "ne" },
                Teachers = new List<string> { "tea" },
                Groups = new List<string> { "gro" },
                Locations = new List<string> { "loc" },
                Type = Appointment.AppointmentType.lesson,
                Remark = "Remark",
                Valid = true,
                Hidden = false,
                Base = true,
                Cancelled = false,
                Modified = true,
                Moved = false,
                New = false,
                ChangeDescription = "Description",
                Created = UnixTimeHelpers.FromUnixTimeSeconds(413642360),
                LastModified = UnixTimeHelpers.FromUnixTimeSeconds(413642360),
                BranchId = 2,
                Branch = "Branch"
            };

            Appointment result = JsonConvert.DeserializeObject<Appointment>(testData);

            Assert.Equal(expected.Id, result.Id);
            Assert.Equal(expected.InstanceId, result.InstanceId);
            Assert.Equal(expected.Start, result.Start);
            Assert.Equal(expected.End, result.End);
            Assert.Equal(expected.StartTimeSlot, result.StartTimeSlot);
            Assert.Equal(expected.EndTimeSlot, result.EndTimeSlot);
            Assert.Equal(expected.Subjects, result.Subjects);
            Assert.Equal(expected.Teachers, result.Teachers);
            Assert.Equal(expected.Groups, result.Groups);
            Assert.Equal(expected.Locations, result.Locations);
            Assert.Equal(expected.Type, result.Type);
            Assert.Equal(expected.Remark, result.Remark);
            Assert.Equal(expected.Valid, result.Valid);
            Assert.Equal(expected.Hidden, result.Hidden);
            Assert.Equal(expected.Base, result.Base);
            Assert.Equal(expected.Cancelled, result.Cancelled);
            Assert.Equal(expected.Modified, result.Modified);
            Assert.Equal(expected.Moved, result.Moved);
            Assert.Equal(expected.New, result.New);
            Assert.Equal(expected.ChangeDescription, result.ChangeDescription);
            Assert.Equal(expected.Created, result.Created);
            Assert.Equal(expected.LastModified, result.LastModified);
            Assert.Equal(expected.BranchId, result.BranchId);
            Assert.Equal(expected.Branch, result.Branch);
        }

        [Fact]
        public static void ShouldDeserializeBasic()
        {
            string testData = "{\"id\":51562,\"appointmentInstance\":21412,\"start\":423642360,\"end\":436234523,\"subjects\":[\"ne\"],\"groups\":[\"gro\"],\"locations\":[\"loc\"],\"type\":\"lesson\",\"valid\":true,\"hidden\":false,\"cancelled\":false,\"modified\":false,\"moved\":false,\"new\":false,\"created\":413642360,\"lastModified\":413642360}";
            Appointment expected = new Appointment
            {
                Id = 51562,
                InstanceId = 21412,
                Start = UnixTimeHelpers.FromUnixTimeSeconds(423642360),
                End = UnixTimeHelpers.FromUnixTimeSeconds(436234523),
                StartTimeSlot = null,
                EndTimeSlot = null,
                Subjects = new List<string> { "ne" },
                Teachers = null,
                Groups = new List<string> { "gro" },
                Locations = new List<string> { "loc" },
                Type = Appointment.AppointmentType.lesson,
                Remark = null,
                Valid = true,
                Hidden = false,
                Base = null,
                Cancelled = false,
                Modified = false,
                Moved = false,
                New = false,
                ChangeDescription = null,
                Created = UnixTimeHelpers.FromUnixTimeSeconds(413642360),
                LastModified = UnixTimeHelpers.FromUnixTimeSeconds(413642360),
                BranchId = null,
                Branch = null
            };

            Appointment result = JsonConvert.DeserializeObject<Appointment>(testData);

            Assert.Equal(expected.Id, result.Id);
            Assert.Equal(expected.InstanceId, result.InstanceId);
            Assert.Equal(expected.Start, result.Start);
            Assert.Equal(expected.End, result.End);
            Assert.Equal(expected.StartTimeSlot, result.StartTimeSlot);
            Assert.Equal(expected.EndTimeSlot, result.EndTimeSlot);
            Assert.Equal(expected.Subjects, result.Subjects);
            Assert.Equal(expected.Teachers, result.Teachers);
            Assert.Equal(expected.Groups, result.Groups);
            Assert.Equal(expected.Locations, result.Locations);
            Assert.Equal(expected.Type, result.Type);
            Assert.Equal(expected.Remark, result.Remark);
            Assert.Equal(expected.Valid, result.Valid);
            Assert.Equal(expected.Hidden, result.Hidden);
            Assert.Equal(expected.Base, result.Base);
            Assert.Equal(expected.Cancelled, result.Cancelled);
            Assert.Equal(expected.Modified, result.Modified);
            Assert.Equal(expected.Moved, result.Moved);
            Assert.Equal(expected.New, result.New);
            Assert.Equal(expected.ChangeDescription, result.ChangeDescription);
            Assert.Equal(expected.Created, result.Created);
            Assert.Equal(expected.LastModified, result.LastModified);
            Assert.Equal(expected.BranchId, result.BranchId);
            Assert.Equal(expected.Branch, result.Branch);
        }
    }
}
