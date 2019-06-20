using System.Collections.Generic;

namespace Courses.Core.Models
{
    public class Program
    {
        public int Id { get; set; }
        public int SchoolYear { get; set; }
        public string ProgramCode { get; set; }
        public string Name { get; set; }
        public int? BeginYear { get; set; }
        public int? EndYear { get; set; }

        public ProgramType ProgramType { get; set; }
        public int? ProgramTypeId { get; set; }

        public bool? isNonTraditionalForFemales { get; set; }
        public bool? isNonTraditionalForMales { get; set; }

        public int? ClusterId { get; set; }
        public Cluster Cluster { get; set; }
        public List<ProgramCourse> ProgramCourses { get; set; }

        //public List<Course> Courses { get; set; } = new List<Course>();

        public List<ProgramCredential> Credentials { get; set; }
        public string ModifyUser { get; set; }
    }
}
