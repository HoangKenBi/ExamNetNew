using System.ComponentModel.DataAnnotations;

namespace ExamNet.entities
{
    public class Exam
    {
        [Key]
        public int ExamId { get; set; }

        [Required(ErrorMessage = "The ExamSubject field is required.")]
        [StringLength(255, ErrorMessage = "The ExamSubject field must be a string with a maximum length of 255.")]
        public string ExamSubject { get; set; }

        [DataType(DataType.Time)]
        public TimeOnly StartTime { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Exam Date")]
        public DateTime ExamDate { get; set; }

        [DataType(DataType.Time)]
        [Display(Name = "Exam Duration")]
        public TimeSpan ExamDuration { get; set; }

        public string Classroom { get; set; }
        public string Faculty { get; set; }
    }
}
