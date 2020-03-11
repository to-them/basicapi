using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace BasicWebApi.Models
{
    public class PersonLogic
    {
        #region JSON
        ICRUD<Person> p;
        public PersonLogic()
        {
            p = new Person_json();
        }

        #region :Create
        public bool CreatePerson(Person model)
        {
            if (p.Create(model))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region :Read
        public List<Person> Persons
        {
            get
            {
                List<Person> ls = new List<Person>();
                ls = p.RetrieveAll();
                if (ls == null || ls.Count() < 1)
                {
                    ls = SeedPerson;
                }
                return ls;

                //return p.RetrieveAll();
            }
        }

        public Person Person(string key)
        {
            return p.Retrieve(key);
        }
        #endregion

        #region :Update
        public bool UpdatePerson(Person model, string key)
        {
            if (p.Update(model, key))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region :Delete
        public bool DeletePerson(string key)
        {
            if (p.Delete(key))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #endregion
        #region :XML
        //Get just xml data
        public List<Person> getPersons
        {
            get
            {
                List<Person> ls = new List<Person>();
                string xml_file_path = Utilities.PersonXmlFilePath;
                DataTable dt = new DataTable();
                dt = Utilities.xmlData(xml_file_path);
                foreach (DataRow dr in dt.Rows)
                {
                    Person p = new Person();
                    p.Id = Int32.Parse(dr["Id"].ToString());
                    p.FirstName = dr["FirstName"].ToString();
                    p.LastName = dr["LastName"].ToString();
                    p.EmailAddress = dr["EmailAddress"].ToString();
                    p.CellphoneNumber = dr["CellphoneNumber"].ToString();

                    ls.Add(p);
                }

                return ls;
            }

        }
        #endregion

        #region :Seed Person Data
        /// <summary>
        /// Initialize the JSON file
        /// </summary>
        public static List<Person> SeedPerson
        {
            get
            {
                List<Person> ls = new List<Person>();
                ls.Add(new Person()
                {
                    Id = 0,
                    FirstName = "Seed First",
                    LastName = "Seed Last",
                    EmailAddress = "seed@email.com",
                    CellphoneNumber = "132-000-9800"
                });
                return ls;
            }
        }
        #endregion

    }
}