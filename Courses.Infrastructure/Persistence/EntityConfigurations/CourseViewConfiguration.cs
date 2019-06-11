using Courses.Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace Courses.Infrastructure.Persistence.EntityConfigurations
{
    public class CourseViewConfiguration : EntityTypeConfiguration<CourseView>
    {
        public CourseViewConfiguration()
        {
            ToTable("v_Courses", "Common");
            Property(s => s.Id).HasColumnName("CourseId");
            Property(s => s.Name).HasColumnName("CourseName");
            Property(s => s.Description).HasColumnName("CourseDescription");
            Property(s => s.SubjectArea).HasColumnName("CourseSubjectArea");
            Property(s => s.CreditType).HasColumnName("CreditTypeName");
            Property(s => s.CourseType).HasColumnName("CourseTypeName");
            //Property(s => s.SubjectAreaId).HasColumnName("CourseSubjectAreaId");
            //Property(s => s.BeginServiceYearId).HasColumnName("BeginServiceYearId");
            //Property(s => s.EndServiceYearId).HasColumnName("EndServiceYearId");
        }
    }
}
