using System.Collections.Generic;

namespace Courses.Core.Models
{
    public class Cluster
    {
        public int Id { get; set; }
        public string ClusterCode { get; set; }
        public string Name { get; set; }

        public ClusterType ClusterType { get; set; }
        public int? ClusterTypeId { get; set; }
        public int? BeginYear { get; set; }
        public int? EndYear { get; set; }
        public List<Program> Programs { get; set; }
    }
}
