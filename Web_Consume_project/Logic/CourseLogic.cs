using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Web_Consume_project.Models;

namespace Web_Consume_project.Logic
{
    public class CourseLogic
    {
        private readonly IConfiguration _configuration;
        string apiStudentUrl = null;
        string apiCourseUrl = null;

        public CourseLogic(IConfiguration configuration)
        {
            _configuration = configuration;
            apiStudentUrl = _configuration.GetValue<string>("WebAPIStudentUrl");
            apiCourseUrl = _configuration.GetValue<string>("WebAPICourseUrl");

        }
        public IEnumerable<Course> GetCourses()
        {
            List<Course> courses = new List<Course>();
            using (HttpClient client = new HttpClient())
            {
                string endpoint = apiCourseUrl + "/GetAllCourses";
                using (var Response = client.GetAsync(endpoint))
                {
                    if (Response.Result.StatusCode == System.Net.HttpStatusCode.OK)
                    {

                        var apiResponse = Response.Result.Content.ReadAsStringAsync().Result;
                        courses = JsonConvert.DeserializeObject<List<Course>>(apiResponse);
                        return courses;
                    }

                    else
                    {
                        return null;
                    }
                }



            }
        }



        public IEnumerable<Student> GetStudentsInCourse(int courseId)
        {

            List<Student> StudentListInfo = new List<Student>();
            using (HttpClient client = new HttpClient())
            {
                string endpoint = apiStudentUrl + "/GetStudentsInCourse/" + courseId;
                using (var Response = client.GetAsync(endpoint))
                {
                    if (Response.Result.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var apiResponse = Response.Result.Content.ReadAsStringAsync().Result;
                        StudentListInfo = JsonConvert.DeserializeObject<List<Student>>(apiResponse);
                        return StudentListInfo;
                    }

                    else
                    {
                        return null;
                    }
                }

            }
        }

        public Course AddCourse(Course course)
        {
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(course), Encoding.UTF8, "application/json");
                string endpoint = apiCourseUrl + "/AddCourse";
                using (var Response = client.PostAsync(endpoint, content))
                {
                    if (Response.Result.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        return course;
                    }

                    else
                    {
                        return null;
                    }
                }

            }
        }


    }
}
