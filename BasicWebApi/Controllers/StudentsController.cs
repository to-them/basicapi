using BasicWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BasicWebApi.Controllers
{
    public class StudentsController : ApiController
    {
        static List<Student> students = new List<Student>()
        {
            new Student() { Id = 1, Name = "Timo" },
            new Student() { Id = 2, Name = "Samo" },
            new Student() { Id = 3, Name = "Johnny" },
            new Student() { Id = 4, Name = "Yeah" }
        };

        /// <summary>
        /// /api/students/
        /// </summary>
        /// <returns>All students</returns>
        public IHttpActionResult Get()
        {
            if (students.Count > 0)
            {
                return Ok(students);
            }
            else
            {
                //return NotFound();
                return Content(HttpStatusCode.NotFound, "No data was returned");
            }
        }

        /// <summary>
        /// /api/students/2
        /// </summary>
        /// <param name="id"></param>
        /// <returns>One student by id</returns>
        public IHttpActionResult Get(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                //return NotFound();
                return Content(HttpStatusCode.NotFound, "Student not found");
            }

            return Ok(student);
        }

        /*
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
        */
    }
}