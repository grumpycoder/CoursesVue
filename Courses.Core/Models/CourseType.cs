namespace Courses.Core.Models
{
    public class CourseType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public bool? IsCore { get; set; }

    }
}