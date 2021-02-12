using Web_Consume_project.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

#nullable disable

namespace Web_Consume_project.Models
{
    public partial class Student 
    {
        public Student()
        {
            StudentCourses = new HashSet<StudentCourse>();
        }

        public int Id { get; set; }

        [Display(Name ="First Name")]
        [Required(ErrorMessage ="Your First name , please")]
        public string FirstName { get; set; }
        [Display(Name ="Last Name")]
        [Required(ErrorMessage ="Your Last name , please")]
        public string LastName { get; set; }
        [Display(Name ="Gender")]
        [Required(ErrorMessage ="Your gender, please")]
        public int GenderId { get; set; }

        IEnumerable<SelectListItem> genderTypes { get; set; }
        
        [Display(Name ="Phone No")]
        [Required(ErrorMessage ="Your Phone number, please")]
        public string Mobile { get; set; }

        public virtual Gender Gender { get; set; }
        public virtual ICollection<StudentCourse> StudentCourses { get; set; }
    }
}
