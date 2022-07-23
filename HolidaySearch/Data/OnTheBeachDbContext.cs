using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidaySearch.Data
{
    public class OnTheBeachDbContext 
    {
        private static OnTheBeachDbContext dbContext;
        
        public OnTheBeachDbContext()
        {
            Flights = new List<Flight>();
            
            LoadJsonData();
        }

        private void LoadJsonData()
        {
            StreamReader streamReader;
            var path = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "Data\\");

            using (streamReader = new StreamReader(String.Format("{0}{1}", path, "FlightData.json")))
            {
                string flightData = streamReader.ReadToEnd();
                Flights.AddRange(JsonConvert.DeserializeObject<List<Flight>>(flightData));

            }
        }
        public List<Flight> Flights { get; set; }

    }
}
