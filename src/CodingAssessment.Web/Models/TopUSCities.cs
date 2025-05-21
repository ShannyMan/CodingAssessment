using System.Collections.Generic;
using System.Linq;

namespace CodingAssessment.Web.Models
{
    public static class TopUSCities
    {
        public static List<string> GetTop50CitiesByPopulation()
        {
            return new List<string>
            {
                "New York, NY",
                "Los Angeles, CA",
                "Chicago, IL",
                "Houston, TX",
                "Phoenix, AZ",
                "Philadelphia, PA",
                "San Antonio, TX",
                "San Diego, CA",
                "Dallas, TX",
                "San Jose, CA",
                "Austin, TX",
                "Jacksonville, FL",
                "Fort Worth, TX",
                "Columbus, OH",
                "Charlotte, NC",
                "San Francisco, CA",
                "Indianapolis, IN",
                "Seattle, WA",
                "Denver, CO",
                "Washington, DC",
                "Boston, MA",
                "El Paso, TX",
                "Nashville, TN",
                "Detroit, MI",
                "Oklahoma City, OK",
                "Portland, OR",
                "Las Vegas, NV",
                "Memphis, TN",
                "Louisville, KY",
                "Baltimore, MD",
                "Milwaukee, WI",
                "Albuquerque, NM",
                "Tucson, AZ",
                "Fresno, CA",
                "Sacramento, CA",
                "Kansas City, MO",
                "Long Beach, CA",
                "Mesa, AZ",
                "Atlanta, GA",
                "Colorado Springs, CO",
                "Raleigh, NC",
                "Omaha, NE",
                "Miami, FL",
                "Oakland, CA",
                "Minneapolis, MN",
                "Tulsa, OK",
                "Cleveland, OH",
                "Wichita, KS",
                "Arlington, TX",
                "New Orleans, LA"
            }.OrderBy(city => city).ToList();
        }
    }
}