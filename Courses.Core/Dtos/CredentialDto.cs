namespace Courses.Core.Dtos
{
    public class CredentialDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CredentialCode { get; set; }

        public string CredentialTypeCode { get; set; }

        public string CredentialTypeName { get; set; }

        public bool IsReimbursable { get; set; }

        public int? BeginYear { get; set; }
        public int? EndYear { get; set; }

    }
}
