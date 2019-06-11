using System.Collections.Generic;

namespace Courses.Core.Models
{
    public class Credential
    {
        public int Id { get; set; }
        public string CredentialCode { get; set; }
        public string Name { get; set; }

        public int CredentialTypeId { get; set; }

        public CredentialType CredentialType { get; set; }

        public bool IsReimbursable { get; set; }

        public List<ProgramCredential> Programs { get; set; }
    }
}
