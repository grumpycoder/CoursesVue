namespace Courses.Core.Models
{
    public class SchoolYear
    {
        public int Id { get; set; }
        public string DisplayYear { get; set; }
        public string Year { get; set; }
        public bool IsCurrent { get; set; }
    }
}