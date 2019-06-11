using Courses.Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace Courses.Infrastructure.Persistence.EntityConfigurations
{
    public class CreditTypeConfiguration : EntityTypeConfiguration<CreditType>
    {
        public CreditTypeConfiguration()
        {
            ToTable("CreditTypes", "Common");
            Property(s => s.Id).HasColumnName("CreditTypeId");
            Property(s => s.Name).HasColumnName("CreditTypeName");
            Property(s => s.Description).HasColumnName("CreditTypeDescription");
        }
    }
}
