using System;
using System.Collections.Generic;

namespace ExamNet.entities
{
    public partial class Class
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public virtual ICollection<Exam> Exams { get; set; } = new List<Exam>();
    }
}