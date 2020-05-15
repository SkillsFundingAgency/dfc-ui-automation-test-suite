using System.Collections.Generic;

namespace SFA.DFC.CompositeApps.UITests.CompositeApp.FindACourse.Models
{
    public class CourseSearchBody
    {
        public string subjectKeyword { get; set; }
        public int distance { get; set; }
        public string providerName { get; set; }
        public IList<string> qualificationLevels { get; set; }
        public IList<int> studyModes { get; set; }
        public IList<int> attendancePatterns { get; set; }
        public IList<int> deliveryModes { get; set; }
        public string town { get; set; }
        public string postcode { get; set; }
        public string sortBy { get; set; }
        public string startDateFrom { get; set; }
        public string startDateTo { get; set; }
        public int limit { get; set; }
        public int start { get; set; }
    }
}
