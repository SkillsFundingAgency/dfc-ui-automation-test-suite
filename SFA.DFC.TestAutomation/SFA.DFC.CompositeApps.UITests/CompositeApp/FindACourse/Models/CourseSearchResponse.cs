using System;
using System.Collections.Generic;

namespace SFA.DFC.CompositeApps.UITests.CompositeApp.FindACourse.Models
{
    public class Region
    {
        public int count { get; set; }
        public string value { get; set; }
    }

    public class ProviderName
    {
        public int count { get; set; }
        public string value { get; set; }
    }

    public class AttendancePattern
    {
        public int count { get; set; }
        public string value { get; set; }
    }

    public class StudyMode
    {
        public int count { get; set; }
        public string value { get; set; }
    }

    public class DeliveryMode
    {
        public int count { get; set; }
        public string value { get; set; }
    }

    public class QualificationLevel
    {
        public int count { get; set; }
        public string value { get; set; }
    }

    public class Facets
    {
        public IList<Region> Region { get; set; }
        public IList<ProviderName> ProviderName { get; set; }
        public IList<AttendancePattern> AttendancePattern { get; set; }
        public IList<StudyMode> StudyMode { get; set; }
        public IList<DeliveryMode> DeliveryMode { get; set; }
        public IList<QualificationLevel> QualificationLevel { get; set; }

    }

    public class VenueLocation
    {
        public double latitude { get; set; }
        public double longitude { get; set; }
    }

    public class Results
    {
        public double searchScore { get; set; }
        public IList<object> distance { get; set; }
        public VenueLocation venueLocation { get; set; }
        public string courseId { get; set; }
        public string courseRunId { get; set; }
        public DateTime qualificationCourseTitle { get; set; }
        public string learnAimRef { get; set; }
        public string qualificationLevel { get; set; }
        public DateTime updatedOn { get; set; }
        public string venueName { get; set; }
        public string venueAddress { get; set; }
        public IList<object> venueAttendancePattern { get; set; }
        public IList<object> venueAttendancePatternDescription { get; set; }
        public string providerName { get; set; }
        public string region { get; set; }
        public string venueStudyMode { get; set; }
        public string venueStudyModeDescription { get; set; }
        public string deliveryMode { get; set; }
        public string deliveryModeDescription { get; set; }
        public IList<object> startDate { get; set; }
        public IList<object> venueTown { get; set; }
        public int cost { get; set; }
        public string costDescription { get; set; }
        public string courseText { get; set; }
        public string ukprn { get; set; }
        public string courseDescription { get; set; }
        public DateTime courseName { get; set; }
        public bool flexibleStartDate { get; set; }
        public string durationUnit { get; set; }
        public IList<object> durationValue { get; set; }
        public bool national { get; set; }
    }
    public class CourseSearchResponse
    {
        public Facets facets { get; set; }
        public IList<Results> results { get; set; }
        public int total { get; set; }
        public int limit { get; set; }
        public int start { get; set; }
    }
}
