namespace Courses.Core.Dtos
{
    public class CourseDto
    {
        public int Id { get; set; }
        public string CourseCode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CipCode { get; set; }
        public int? BeginYear { get; set; }
        public int? EndYear { get; set; }

        public string LowGrade { get; set; }
        public string HighGrade { get; set; }
        public string CreditType { get; set; }
        public string CourseType { get; set; }
        public string ClassType { get; set; }
        public string SubjectArea { get; set; }
        public string Status { get; set; }

       // public List<ProgramDto> CareerTechPrograms { get; set; }
    }
}
