using System.ComponentModel.DataAnnotations;

namespace ExamNet.entities
{
    public class Faculty
    {
        public int ExamId { get; set; }

        [Required(ErrorMessage = "Faculty field is required.")]
        [StringLength(255, ErrorMessage = "The ExamSubject field must be a string with a maximum length of 255.")]
        public string Name { get; set; }
    }
}
