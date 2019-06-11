namespace Courses.Core.Models
{
    public class CourseView
    {
        public int Id { get; set; }
        public string CourseCode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CipCode { get; set; }
        public string BeginServiceYear { get; set; }
        public string EndServiceYear { get; set; }
        public string LowGrade { get; set; }
        public string HighGrade { get; set; }
        public string CreditType { get; set; }
        public string CourseType { get; set; }
        public string ClassType { get; set; }
        public string SubjectArea { get; set; }
        public string Status { get; set; }

    }
}
