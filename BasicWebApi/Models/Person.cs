using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace BasicWebApi.Models
{
    public class Person
    {
        /// <summary>
        /// The unique identifier for the person.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The first name of the person.
        /// </summary>
        //[Required(ErrorMessage = "Title is required")]
        public string FirstName { get; set; }

        /// <summary>
        /// The last name of the person.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// The primary email address of the person.
        /// </summary>
        public string EmailAddress { get; set; }

        /// <summary>
        /// The primary cell phone number of the person.
        /// </summary>
        public string CellphoneNumber { get; set; }

        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
                //return $"{ FirstName } { LastName }";
            }
        }
        
    }

    public class Person_Table
    {
        protected string TableName = "tbl_person"; //DB table name
        protected string colId = "Id";
        protected string colFirstName = "FirstName";
        protected string colLastName = "LastName";
        protected string colEmailAddress = "EmailAddress";
        protected string colCellphoneNumber = "CellphoneNumber";
    }
}