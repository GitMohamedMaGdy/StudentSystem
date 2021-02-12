using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Web_Consume_project.Models;

namespace Web_Consume_project.ViewModels
{
    public class StudentInCourseListViewModel
    {
       public IEnumerable<Student> Students { get; set; }
        public IEnumerable<Course> Courses { get; set; }

        [Display(Name ="Select Course")]
        public string SelectedCourse { get; set; }

    }

}
