namespace Courses.Core.Dtos
{
    public class CourseEditDto
    {
        public int Id { get; set; }
        public string CourseCode { get; set; }
        public string CipCode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int? BeginServiceYearId { get; set; }
        public int? EndServiceYearId { get; set; }

        public int? LowGradeId { get; set; }
        public int? HighGradeId { get; set; }
        public int? CourseTypeId { get; set; }
        public int? CreditTypeId { get; set; }
        public int? ClassTypeId { get; set; }
        public int? SubjectAreaId { get; set; }

    }
}
