using System.ComponentModel.DataAnnotations;

namespace ExamNet.entities
{
    public class Exam
    {
        [Key]
        public int ExamId { get; set; }

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
