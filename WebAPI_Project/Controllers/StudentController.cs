using Microsoft.AspNetCore.Mvc;
using StudentSystem.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_Project.Core.Models;
using WWebAPI_Project.Core.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {

        private readonly IRepository<Student> Studentcontext;
        private readonly IRepository<StudentCourse> StudentCoursecontext;
        public StudentController(IRepository<Student> Studentcontext, IRepository<StudentCourse> StudentCoursecontext)
        {
            this.Studentcontext = Studentcontext;
            this.StudentCoursecontext = StudentCoursecontext;

        }
        // GET: api/<StudentController>
        [HttpGet]
        [Route("GetAllStudents")]
        public IActionResult GetAllStudents()
        {
            try
            {
                IList<Student> students = Studentcontext.Collection().ToList();
                if (students == null)
                {

                    return NotFound();
                }
                return Ok(students);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // GET api/<StudentController>/5
        [HttpGet]
        [Route("GetStudent/{Id}")]

        public IActionResult GetStudent(int Id)
        {
            try
            {
                Student student = Studentcontext.Find(Id);
                if (student == null)
                {
                    return BadRequest();
                }
                return Ok(student);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // POST api/<StudentController>

        [HttpPost]
        [Route("AddStudent")]

        public IActionResult AddStudent([FromBody] Student student)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    if (Studentcontext.Insert(student))
                    {
                        Studentcontext.Commit();
                        return Ok(student);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {

                    return BadRequest();
                }

            }

            return BadRequest();
        }





        // PUT api/<StudentController>/5
        [HttpPut]
        [Route("UpdateStudent")]

        public IActionResult Put([FromBody] Student student)
        {
            int id = student.Id;
            if (ModelState.IsValid)
            {
                try
                {
                    if (id != 0)
                    {
                        Studentcontext.Update(student);
                        Studentcontext.Commit();


                        return Ok();
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception e)
                {
                    e.Message.ToString();


                    return BadRequest();
                }



            }

            return BadRequest();
        }



        // DELETE api/<StudentController>/5
        [HttpDelete]
        [Route("DeleteStudent/{Id}")]

        public IActionResult DeleteStudent(int Id)
        {
            try
            {

                if (!Studentcontext.Delete(Id))
                {
                    return NotFound();
                }
                Studentcontext.Commit();

                return Ok();
            }
            catch (Exception e)

            {

                e.Message.ToString();
                return BadRequest();
            }

        }




        [HttpGet]
        [Route("GetStudentsInCourse/{CourseId}")]

        public IActionResult GetStudentsInfoInCourse(int CourseId)
        {
            try
            {
                var studentInfo = (from student in Studentcontext.Collection()
                                   join studentcourse in StudentCoursecontext.Collection()
                                   on student.Id equals studentcourse.StudentId
                                   where studentcourse.CourseId == CourseId
                                   select student).ToList();

                if (studentInfo != null)
                {
                    return Ok(studentInfo);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception)
            {
                return BadRequest();

            }

        }


    }
}
