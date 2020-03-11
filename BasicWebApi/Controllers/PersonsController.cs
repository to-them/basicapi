using BasicWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BasicWebApi.Controllers
{
    public class PersonsController : ApiController
    {
        private PersonLogic p;

        [Route("api/Persons/GetFirstNames/{userId:int}/{age:int}")]
        [HttpGet]
        public List<string> GetFirstNames(int userId, int age)
        {
            List<string> ls = new List<string>();
            p = new PersonLogic();
            foreach (var f in p.getPersons)
            {
                ls.Add(f.FirstName);
            }
            return ls;
        }

        //[Route("api/Persons/FirstNames")]
        //[HttpGet]
        //public List<string> GetFirstNames()
        //{
        //    List<string> ls = new List<string>();
        //    p = new bll_Person();
        //    foreach (var f in p.getPersons)
        //    {
        //        ls.Add(f.FirstName);
        //    }
        //    return ls;
        //}

        // GET api/<controller>
        public IEnumerable<Person> Get()
        {
            p = new PersonLogic();
            return p.Persons;
            //return p.getPersons; //xml
        }

        // GET api/<controller>/5
        public Person Get(int id)
        {
            p = new PersonLogic();
            return p.Persons.FirstOrDefault(x => x.Id == id);
            //return p.getPersons.FirstOrDefault(x => x.Id == id); //xml
        }

        // POST api/<controller>
        public void Post(Person model)
        {
            p = new PersonLogic();
            p.CreatePerson(model);
        }
        //public void Post([FromBody]string value)
        //{
        //}

        // PUT api/<controller>/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        public void Put(int id, Person model)
        {
            p = new PersonLogic();
            p.UpdatePerson(model, id.ToString());
        }
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        // DELETE api/<controller>/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            p = new PersonLogic();
            p.DeletePerson(id.ToString());
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