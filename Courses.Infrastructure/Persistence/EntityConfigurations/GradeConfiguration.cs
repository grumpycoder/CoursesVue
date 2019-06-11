using Courses.Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace Courses.Infrastructure.Persistence.EntityConfigurations
{
    public class GradeConfiguration : EntityTypeConfiguration<Grade>
    {
        public GradeConfiguration()
        {
            ToTable("Grades", "Common");
            Property(s => s.Id).HasColumnName("GradeId");
            Property(s => s.Name).HasColumnName("Grade");
            Property(s => s.Description).HasColumnName("Description");
        }
    }
}
