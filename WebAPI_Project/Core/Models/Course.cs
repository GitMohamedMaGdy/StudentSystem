using StudentSystem.Core.Models;
using System;
using System.Collections.Generic;

#nullable disable

namespace WebAPI_Project.Core.Models
{
    public partial class Course :BaseEntity
    {
        public Course()
        {
            StudentCourses = new HashSet<StudentCourse>();
        }

        public string Name { get; set; }
        public int NoOfStudents { get; set; }

        public virtual ICollection<StudentCourse> StudentCourses { get; set; }
    }
}
