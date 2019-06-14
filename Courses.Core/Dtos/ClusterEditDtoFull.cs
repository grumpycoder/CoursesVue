namespace Courses.Core.Dtos
{
    public class ClusterEditDto
    {
        public int Id { get; set; }
        public string ClusterCode { get; set; }
        public string Name { get; set; }
        public int? ClusterTypeId { get; set; }
        public int? BeginYear { get; set; }
        public int? EndYear { get; set; }
    }
}
