using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Hosting;

namespace BasicWebApi.Models
{
    public class Utilities
    {
        public static string AppDataFolder = HostingEnvironment.MapPath(AppKeyLookup("fileFolder"));
        public static string ErrorFolder = HostingEnvironment.MapPath(AppKeyLookup("errorFolder"));
        public static string PersonXmlFilePath = AppDataFolder + @"\Persons.xml";
        public const string PersonJsonFile = "Persons.json";
        public static string PersonJsonFilePath = AppDataFolder + "\\" + PersonJsonFile;

        //App_Settings lookup
        /// <summary>
        /// Get App_Settings value specified in the config file
        /// </summary>
        /// <param name="key">App_Settings key</param>
        /// <returns>Returns the value</returns>
        public static string AppKeyLookup(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }

        static DataTable dt = null;
        static DataSet ds = null; //for data set we can also use data table

        //Read xml data
        public static DataTable xmlData(string xml_file_path)
        {
            ds = new DataSet();
            ds.ReadXml(xml_file_path);
            dt = new DataTable();
            dt = ds.Tables[0];
            return dt;
        }
    }
}