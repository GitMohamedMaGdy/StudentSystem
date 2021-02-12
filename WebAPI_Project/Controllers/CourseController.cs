using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentSystem.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_Project.Core.Models;

namespace WebAPI_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {

        private readonly IRepository<Course> context;
        public CourseController(IRepository<Course> context)
        {
            this.context = context;

        }
        // GET: api/<CourseController>
        [HttpGet]
        [Route("GetAllCourses")]
        public IActionResult GetAllCourses()
        {
            try
            {
                IList<Course> courses = context.Collection().ToList();
                if (courses == null)
                {

                    return NotFound();
                }
                return Ok(courses);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // GET api/<CourseController>/5
        [HttpGet]
        [Route("GetCourse/{Id}")]

        public IActionResult GetCourse(int Id)
        {
            try
            {
                Course course = context.Find(Id);
                if (course == null)
                {
                    return BadRequest();
                }
                return Ok(course);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // POST api/<CourseController>

        [HttpPost]
        [Route("AddCourse")]

        public IActionResult AddCourse([FromBody] Course course)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    if (context.Insert(course))
                    {
                        context.Commit();
                        return Ok(course);
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





        // PUT api/<CourseController>/5
        [HttpPut]
        [Route("UpdateCourse")]

        public IActionResult Put([FromBody] Course course)
        {
            int id = course.Id;
            if (ModelState.IsValid)
            {
                try
                {
                    if (id != 0)
                    {
                        context.Update(course);
                        context.Commit();


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



        // DELETE api/<CourseController>/5
        [HttpDelete]
        [Route("DeleteCourse/{Id}")]

        public IActionResult DeleteCourse(int Id)
        {
            try
            {

                if (!context.Delete(Id))
                {
                    return NotFound();
                }
                context.Commit();

                return Ok();
            }
            catch (Exception)
            {

                return BadRequest();
            }

        }
    }
}
