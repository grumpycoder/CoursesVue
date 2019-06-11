using Courses.Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace Courses.Infrastructure.Persistence.EntityConfigurations
{
    public class ClusterConfiguration : EntityTypeConfiguration<Cluster>
    {
        public ClusterConfiguration()
        {
            ToTable("Cluster", "CareerTech");
            Property(s => s.Id).HasColumnName("ClusterId");
            Property(s => s.Name).HasColumnName("Cluster");
            Property(s => s.ClusterTypeId).HasColumnName("ClusterTypeId");
        }
    }
}
