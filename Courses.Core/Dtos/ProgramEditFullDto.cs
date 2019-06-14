using Courses.Core.Models;
using System.Collections.Generic;

namespace Courses.Core.Dtos
{
    public class ProgramEditFullDto
    {
        public int Id { get; set; }
        public int SchoolYear { get; set; }
        public string ProgramCode { get; set; }
        public string Name { get; set; }
        public int? BeginYear { get; set; }
        public int? EndYear { get; set; }
        public int? ProgramTypeId { get; set; }
        public int? ClusterId { get; set; }

        public List<CredentialDto> Credentials { get; set; }
        
    }
}