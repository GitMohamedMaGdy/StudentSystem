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
    public class StudentLogic
    {
        private readonly IConfiguration _configuration;
        string apiStudentUrl = null;
        string apiCourseUrl = null;

        public StudentLogic(IConfiguration configuration)
        {
            _configuration = configuration;
            apiStudentUrl = _configuration.GetValue<string>("WebAPIStudentUrl");
            apiCourseUrl = _configuration.GetValue<string>("WebAPICourseUrl");

        }

        public Student AddStudent(Student student)
        {
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(student), Encoding.UTF8, "application/json");
                string endpoint = apiStudentUrl + "/AddStudent";
                using (var Response = client.PostAsync(endpoint, content))
                {
                    if (Response.Result.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        return student;
                    }
                    
                    else
                    {
                        return null;
                    }
                }

            }
        }

        public bool UpdateStudent(Student student)
        {
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(student), Encoding.UTF8, "application/json");
                string endpoint = apiStudentUrl + "/UpdateStudent";
                using (var Response = client.PutAsync(endpoint, content))
                {
                    if (Response.Result.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        return true;
                    }

                    else
                    {
                        return false;
                    }
                }

            }
        }

        public bool DeleteStudent(int Id)
        {
            using (HttpClient client = new HttpClient())
            {
                string endpoint = apiStudentUrl + "/DeleteStudent/" + Id;
                using (var Response = client.DeleteAsync(endpoint))
                {
                    if (Response.Result.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        return true;
                    }

                    else
                    {
                        return false;
                    }
                }

            }
        }

        public Student GetStudentById(int Id)
        {

            Student student = new Student();
            using (HttpClient client = new HttpClient())
            {
                string endpoint = apiStudentUrl + "/GetStudent/" + Id;
                using (var Response = client.GetAsync(endpoint))
                {
                    if (Response.Result.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var apiResponse = Response.Result.Content.ReadAsStringAsync().Result;
                        student = JsonConvert.DeserializeObject<Student>(apiResponse);
                        return student;
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
