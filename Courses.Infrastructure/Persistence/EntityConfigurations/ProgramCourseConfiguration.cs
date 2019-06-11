using Courses.Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace Courses.Infrastructure.Persistence.EntityConfigurations
{
    public class ProgramCourseConfiguration : EntityTypeConfiguration<ProgramCourse>
    {
        public ProgramCourseConfiguration()
        {
            ToTable("ProgramCourse", "CareerTech");
            Property(s => s.Id).HasColumnName("ProgramCourseId");
            //Property(s => s.ProgramId).HasColumnName("ProgramId");
            //Property(s => s.CourseId).HasColumnName("CourseId");
        }
    }
}
