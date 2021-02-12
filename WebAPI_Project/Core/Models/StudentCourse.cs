using StudentSystem.Core.Models;
using System;
using System.Collections.Generic;
using WWebAPI_Project.Core.Models;

#nullable disable

namespace WebAPI_Project.Core.Models
{
    public partial class StudentCourse : BaseEntity
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }

        public virtual Course Course { get; set; }
        public virtual Student Student { get; set; }
    }
}
