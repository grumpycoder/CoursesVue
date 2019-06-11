using Courses.Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace Courses.Infrastructure.Persistence.EntityConfigurations
{
    public class ProgramConfiguration : EntityTypeConfiguration<Program>
    {
        public ProgramConfiguration()
        {
            ToTable("Program", "CareerTech");
            Property(s => s.Id).HasColumnName("ProgramId");
            Property(s => s.Name).HasColumnName("Program");
        }
    }
}
