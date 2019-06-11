using Courses.Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace Courses.Infrastructure.Persistence.EntityConfigurations
{
    public class CredentialConfiguration : EntityTypeConfiguration<Credential>
    {
        public CredentialConfiguration()
        {
            ToTable("Credential", "CareerTech");
            Property(s => s.Id).HasColumnName("CredentialId");
            Property(s => s.Name).HasColumnName("Credential");
            Property(s => s.CredentialCode).HasColumnName("CredentialCode");
            Property(s => s.IsReimbursable).HasColumnName("Reimbursable");
        }
    }
}
