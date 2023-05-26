using System.ComponentModel.DataAnnotations;

namespace ExamNet.entities
{
    public class Class
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Class field is required.")]
        [StringLength(255, ErrorMessage = "The ExamSubject field must be a string with a maximum length of 255.")]
        public string name { get; set; }
    }
}
