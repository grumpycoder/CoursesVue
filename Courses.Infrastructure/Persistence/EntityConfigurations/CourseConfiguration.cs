using System.Data.Entity.ModelConfiguration;
using Courses.Core.Models;

namespace Courses.Infrastructure.Persistence.EntityConfigurations
{
    public class CourseConfiguration : EntityTypeConfiguration<Course>
    {
        public CourseConfiguration()
        {
            ToTable("Courses", "Common");
            Property(s => s.Id).HasColumnName("CourseId");
            Property(s => s.Name).HasColumnName("CourseName");
            Property(s => s.Description).HasColumnName("CourseDescription");

            Property(s => s.BeginServiceYearId).HasColumnName("BeginServiceSchoolYearId");
            Property(s => s.EndServiceYearId).HasColumnName("EndServiceSchoolYearId");
            Property(s => s.LowGradeId).HasColumnName("LowGradeId");
            Property(s => s.HighGradeId).HasColumnName("HighGradeId");
            Property(s => s.CourseTypeId).HasColumnName("CourseTypeId");
            Property(s => s.ClassTypeId).HasColumnName("ClassTypeId");
            Property(s => s.CreditTypeId).HasColumnName("CreditTypeId");
            Property(s => s.CreditTypeId).HasColumnName("CreditTypeId");
            Property(s => s.SubjectAreaId).HasColumnName("CourseSubjectAreaId");

            HasMany<ProgramCourse>(s => s.ProgramCourses)
                .WithRequired(s => s.Course);

            //HasMany<Program>(s => s.Programs)
            //    .WithMany(c => c.Courses)
            //    .Map(x =>
            //    {
            //        x.MapLeftKey("CourseId");
            //        x.MapRightKey("ProgramId");
            //        x.ToTable("ProgramCourse", "CareerTech");
            //    });

        }
    }
}
