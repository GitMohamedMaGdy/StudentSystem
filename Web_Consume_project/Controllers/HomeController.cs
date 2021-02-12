using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Web_Consume_project.Logic;
using Web_Consume_project.Models;
using Web_Consume_project.ViewModels;

namespace Web_Consume_project.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _configuration;
        CourseLogic _courseLogic;
        StudentLogic _studentLogic;

        StudentInCourseListViewModel StudentInCourseVM;

        public HomeController(IConfiguration configuration)
        {
            _configuration = configuration;
            _courseLogic = new CourseLogic(_configuration);
            _studentLogic = new StudentLogic(_configuration);

        }

        public IActionResult Index(int CourseId)
        {

            StudentInCourseVM = new StudentInCourseListViewModel();
            StudentInCourseVM.Courses = _courseLogic.GetCourses();
            //StudentInCourseVM.Students = _courseLogic.GetStudentsInCourse(CourseId);
            return View(StudentInCourseVM);

        }

        public PartialViewResult GetStudentInfo(int CourseId)
        {

            IEnumerable<Student> students = new List<Student>();
            students = _courseLogic.GetStudentsInCourse(CourseId);
            return PartialView("_studentInfo", students);

        }
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            Student student = _studentLogic.GetStudentById(Id);
            return View(student);

        }

        [HttpPost]
        public IActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
               
                if (_studentLogic.UpdateStudent(student))
                {
                    return RedirectToAction("Index");

                }
                return View();

            }
            return View();

        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            Student student = _studentLogic.GetStudentById(Id);
        
            return View(student);

        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult ConfirmDelete(int Id)
        {

            if (_studentLogic.DeleteStudent(Id))
            {
                return RedirectToAction("Index");

            }

            return View();

        }


        [HttpGet]
        public IActionResult AddStudent()
        {
            List<SelectListItem> genderTypes = new List<SelectListItem>();
            genderTypes.Add(new SelectListItem { Text = "Male", Value = "1" });
            genderTypes.Add(new SelectListItem { Text = "Female", Value = "2" });
            ViewBag.genderTypes = genderTypes;
            return View(new Student());
        }
        [HttpPost]
        public IActionResult AddStudent(Student student)
        {
            if (ModelState.IsValid)
            {
                Student student1 = _studentLogic.AddStudent(student);
                if (student1 != null)
                {
                    return RedirectToAction("Index");

                }
                else
                {
                    ModelState.AddModelError("Error", "Error in adding Student");
                    return View();

                }
            }
            else
            {
                ModelState.AddModelError("Error", "Validation Error");

                return View();
            }

        }

        [HttpGet]
        public IActionResult AddCourse()
        {

            return View(new Course());
        }
        [HttpPost]
        public IActionResult AddCourse(Course course)
        {
            if (ModelState.IsValid)
            {
                Course course1 = _courseLogic.AddCourse(course);
                if (course1 != null)
                {
                    return RedirectToAction("Index");

                }
                else
                {
                    ModelState.AddModelError("Error", "Error in adding Course");
                    return View();

                }
            }
            else
            {
                ModelState.AddModelError("Error", "Validation Error");

                return View();
            }

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }



    }
}
