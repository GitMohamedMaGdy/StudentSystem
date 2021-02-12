using Web_Consume_project.Models;
using System;
using System.Collections.Generic;

#nullable disable

namespace Web_Consume_project.Models
{
    public partial class StudentCourse 
    {
        public int Id { get; set; }

        public int StudentId { get; set; }
        public int CourseId { get; set; }

        public virtual Course Course { get; set; }
        public virtual Student Student { get; set; }
    }
}
