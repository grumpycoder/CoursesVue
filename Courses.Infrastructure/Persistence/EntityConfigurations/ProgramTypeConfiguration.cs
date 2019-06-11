using Courses.Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace Courses.Infrastructure.Persistence.EntityConfigurations
{
    public class ProgramTypeConfiguration : EntityTypeConfiguration<ProgramType>
    {
        public ProgramTypeConfiguration()
        {
            ToTable("ProgramType", "CareerTech");
            Property(s => s.Id).HasColumnName("ProgramTypeId");
            Property(s => s.Name).HasColumnName("ProgramType");
            Property(s => s.Code).HasColumnName("ProgramTypeCode");
        }
    }
}
