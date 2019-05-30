using System.ComponentModel.DataAnnotations;

namespace Classroom.Common.Models.Api
{
    public class ClassInputModel
    {
        [Required]
        [StringLength(255, ErrorMessage = "Identifier too long (255 character limit).")]
        public string Name { get; set; }
        [StringLength(4000, ErrorMessage = "Identifier too long (4000 character limit).")]
        public string Description { get; set; }
    }
}