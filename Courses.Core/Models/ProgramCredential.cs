namespace Courses.Core.Models
{
    public class ProgramCredential
    {
        public int Id { get; set; }
        public int ProgramId { get; set; }
        public int CredentialId { get; set; }

        public string ModifiyUser { get; set; }

        public Program Program { get; set; }

        public Credential Credential { get; set; }
    }
}

