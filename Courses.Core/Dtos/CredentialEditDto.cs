namespace Courses.Core.Dtos
{
    public class CredentialEditDto
    {
        public int Id { get; set; }
        public string CredentialCode { get; set; }
        public string Name { get; set; }

        public int CredentialTypeId { get; set; }

        public bool IsReimbursable { get; set; }
        
        public int? BeginYear { get; set; }
        public int? EndYear { get; set; }
    }
}
