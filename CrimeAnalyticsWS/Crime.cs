using CrimeAnalytics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace CrimeAnalyticsWS
{
    [DataContract]
    public class wsCrime
    {
        [DataMember]
        public string CrimeNumber { get; set; }

        [DataMember]
        public DateTime MonthReported { get; set; }

        [DataMember]
        public string ReportedBy { get; set; }

        [DataMember]
        public string FallsWithin { get; set; }

        [DataMember]
        public float Longitude { get; set; }

        [DataMember]
        public float Latitude { get; set; }

        [DataMember]
        public string Location { get; set; }

        [DataMember]//Something to do with boundaries.
        public string LSOACode { get; set; }

        [DataMember]//Something to do with boundaries.
        public string LSOAName { get; set; }

        [DataMember]
        public int CategoryID { get; set; }

        [DataMember]
        public string Context { get; set; }
        
        [DataMember]
        public string Icon { get; set; }
        
        [DataMember]
        public string CategoryName { get; set; }

        public wsCrime(Crime dbCrime)
        {
            CrimeNumber = dbCrime.CrimeNumber;
            MonthReported = dbCrime.MonthReported;
            ReportedBy = dbCrime.ReportedBy;
            FallsWithin = dbCrime.FallsWithin;
            Longitude = dbCrime.Longitude;
            Latitude = dbCrime.Latitude;
            Location = dbCrime.Location;
            LSOACode = dbCrime.LSOACode;
            LSOAName = dbCrime.LSOAName;
            CategoryID = (int)dbCrime.CategoryID;
            Context = dbCrime.Context;
            Icon = dbCrime.Icon;
            CategoryName = dbCrime.CategoryName;
        }
    }
}