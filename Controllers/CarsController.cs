using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using project5.Models;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;


namespace project5.Controllers
{
    public class CarsController : Controller
    {
        public static string ConnString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            }
        }
       
        
        // GET: Cars//list 

        public ActionResult list()
        {
            List<Cars> car = new List<Cars>();
            using (SqlConnection connection = new SqlConnection(ConnString))
            {

               
                connection.Open();
                string queryString = "SELECT * FROM Car";
                SqlCommand command =
                new SqlCommand(queryString, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Cars car1 = new Cars();
                    car1.Id =reader.GetValue(0).ToString();
                    car1.Name = reader.GetValue(1).ToString();
                 ///   ViewBag.Cars = car1;
                    car.Add(car1);

                }

                // Call Close when done reading.
                reader.Close();
                connection.Close();// it is importnat to close the connection 



               
            }
            return View(car);

        }
    }
}

        
    