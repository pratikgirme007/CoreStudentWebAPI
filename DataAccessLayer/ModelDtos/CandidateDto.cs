using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CoreStudentWebAPI.DataAccessLayer.ModelDtos
{
    public class CandidateDto
    {
        [JsonIgnore]
        public int CandidateId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string Gender { get; set; }
    }
}
