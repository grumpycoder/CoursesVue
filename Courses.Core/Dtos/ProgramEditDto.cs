namespace Courses.Core.Dtos
{
    public class ProgramEditDto
    {
        public int Id { get; set; }
        public int SchoolYear { get; set; }
        public string ProgramCode { get; set; }
        public string Name { get; set; }
        public int? BeginYear { get; set; }
        public int? EndYear { get; set; }
        public int? ProgramTypeId { get; set; }

        public int? ClusterId { get; set; }
        public bool? isNonTraditionalForFemales { get; set; }
        public bool? isNonTraditionalForMales { get; set; }

    }
}
