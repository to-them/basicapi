using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BasicWebApi.Models
{
    public class Person_json : Person_Table, ICRUD<Person>
    {
        string file_path = Utilities.PersonJsonFile.FullFilePath(); //Use "PersonJsonFile" to include file name to "FullFilePath"
        //string file_path = bll_Utilities.PersonJsonFilePath;
        public bool Create(Person obj)
        {
            try
            {
                List<Person> people = PersonJsonProcessor.getJsonDataObject(file_path);

                int currentId = 1;

                if (people != null)
                {
                    currentId = people.OrderByDescending(x => x.Id).First().Id + 1;
                }

                //if (people.Count > 0)
                //{
                //    currentId = people.OrderByDescending(x => x.Id).First().Id + 1;
                //}

                obj.Id = currentId;

                string json_basedata = PersonJsonProcessor.getJsonDataString(file_path);
                string s = PersonJsonProcessor.AddObjectsToJson(json_basedata, obj, file_path);

                return true;
            }
            catch (System.Exception ex)
            {
                string error = "Create person json file exceptio: " + ex.Message;
                ErrorHandling.WriteError(error);
                return false;
            }
        }

        public Person Retrieve(string key)
        {
            var person = (from s in RetrieveAll() where key == s.Id.ToString() select s).FirstOrDefault();
            return person;
        }

        public List<Person> RetrieveAll()
        {
            return PersonJsonProcessor.getJsonDataObject(file_path);
        }

        public bool Update(Person obj, string key)
        {
            int id = Int32.Parse(key);
            if (PersonJsonProcessor.UpdateRow(file_path, id, obj))
                return true;
            else
                return false;
        }

        public bool Delete(string key)
        {
            int id = Int32.Parse(key);
            if (PersonJsonProcessor.DeleteRow(file_path, id))
                return true;
            else
                return false;
        }
    }
}