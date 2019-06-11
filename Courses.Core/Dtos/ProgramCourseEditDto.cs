namespace Courses.Core.Dtos
{
    public class ProgramCourseEditDto
    {
        public int Id { get; set; }
        public int ProgramId { get; set; }
        public int CourseId { get; set; }

        public bool? IsFoundation { get; set; }
        public bool? IsRequired { get; set; }
        public bool? IsElective { get; set; }
        public bool? IsActive { get; set; }
    }
}
