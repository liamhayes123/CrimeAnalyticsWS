using CrimeAnalytics;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web.Script.Serialization;

namespace CrimeAnalyticsWS
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public string GetData(string value)
        {
            return string.Format("You entered: {0}", value);
        }

        public List<wsCrime> GetAllCrimes()
        {
            List<wsCrime> results = new List<wsCrime>();
            List<Crime> dbCrimes = DatabaseCalls.GetAllCrimes();
            foreach (Crime dbCrime in dbCrimes)
            {
                results.Add(new wsCrime(dbCrime));
            }

            return results;
        }

        public List<wsCrime> GetAllCrimesInBoundary(string coordinates)
        {
            List<wsCrime> results = new List<wsCrime>();
            JavaScriptSerializer js = new JavaScriptSerializer();
            List<Coordinates> coords = js.Deserialize<List<Coordinates>>(coordinates);
            List<Crime> dbCrimes = DatabaseCalls.GetAllCrimesInBoundary(coords);
            foreach (Crime dbCrime in dbCrimes)
            {
                results.Add(new wsCrime(dbCrime));
            }
            return results;
        }

        public List<wsCrime> GetAllCrimesInBoundaryByCategory(string coordinates, string selectedCategories, string fromDate, string toDate)
        {
            string[] categoriesArray = JsonConvert.DeserializeObject<string[]>(selectedCategories);
            string categories = string.Join(",", categoriesArray);
            List<wsCrime> results = new List<wsCrime>();
            JavaScriptSerializer js = new JavaScriptSerializer();
            List<Coordinates> coords = js.Deserialize<List<Coordinates>>(coordinates);

            fromDate = JsonConvert.DeserializeObject<DateTime>(fromDate).ToString("yyyy-MM-dd");
            toDate = JsonConvert.DeserializeObject<DateTime>(toDate).ToString("yyyy-MM-dd");

            List<Crime> dbCrimes = DatabaseCalls.GetAllCrimesInBoundaryByCategory(coords, categories, fromDate, toDate);
            foreach (Crime dbCrime in dbCrimes)
            {
                results.Add(new wsCrime(dbCrime));
            }
            return results;
        }
    }
}
