using StudentSystem.Core.Models;
using System;
using System.Collections.Generic;
using WebAPI_Project.Core.Models;

#nullable disable

namespace WWebAPI_Project.Core.Models
{
    public partial class Student : BaseEntity
    {
        public Student()
        {
            StudentCourses = new HashSet<StudentCourse>();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int GenderId { get; set; }
        public string Mobile { get; set; }

        public virtual Gender Gender { get; set; }
        public virtual ICollection<StudentCourse> StudentCourses { get; set; }
    }
}
