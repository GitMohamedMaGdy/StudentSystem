using Web_Consume_project.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Web_Consume_project.Models
{
    public partial class Course
    {

        public int Id { get; set; }


        [Display(Name = "Course name")]
        [Required(ErrorMessage = "Your Course, please")]
        public string Name { get; set; }

        [Display(Name = "Capacity")]
        [Required(ErrorMessage = "Add Course Capcity,please ")] 
        public int NoOfStudents { get; set; }

        public virtual ICollection<StudentCourse> StudentCourses { get; set; }

        public Course()
        {
            StudentCourses = new HashSet<StudentCourse>();
        }

    }
}
