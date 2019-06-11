using Courses.Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace Courses.Infrastructure.Persistence.EntityConfigurations
{
    public class ClassTypeConfiguration : EntityTypeConfiguration<ClassType>
    {
        public ClassTypeConfiguration()
        {
            ToTable("ClassTypes", "Common");
            Property(s => s.Id).HasColumnName("Id");
            Property(s => s.Name).HasColumnName("Name");
            Property(s => s.Description).HasColumnName("Description");
        }
    }
}
