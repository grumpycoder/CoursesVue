namespace Courses.Core.Dtos
{
    public class ProgramDto
    {
        public int ProgramId { get; set; }
        //public int ClusterId { get; set; }

        public string ProgramCode { get; set; }
        public string ClusterCode { get; set; }

        public string ProgramName { get; set; }
        public string ClusterName { get; set; }

        public int? BeginYear { get; set; }
        public int? EndYear { get; set; }

        public int? ClusterId { get; set; }
        public bool? isNonTraditionalForFemales { get; set; }
        public bool? isNonTraditionalForMales { get; set; }


    }
}
