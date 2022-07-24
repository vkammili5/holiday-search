using HolidaySearchOTB.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidaySearchOTB.Data
{
    public class OnTheBeachDbContext
    {
        private static OnTheBeachDbContext dbContext;

        public OnTheBeachDbContext()
        {
            Flights = new List<Flight>();
            Hotels = new List<Hotel>();

            LoadJsonData();
        }

        private void LoadJsonData()
        {
            StreamReader streamReader;

            // using reflection for the test project to identify the file
            var path = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "Data\\");

            using (streamReader = new StreamReader(String.Format("{0}{1}", path, "FlightData.json")))
            {
                string flightData = streamReader.ReadToEnd();

                Flights.AddRange(JsonConvert.DeserializeObject<List<Flight>>(flightData));
            }

            //using (streamReader = new StreamReader("~/HotelData.json"))
            using (streamReader = new StreamReader(String.Format("{0}{1}", path, "HotelData.json")))
            {
                string hotelData = streamReader.ReadToEnd();

                Hotels.AddRange(JsonConvert.DeserializeObject<List<Hotel>>(hotelData));
            }
        }

        public List<Flight> Flights { get; set; }
        public List<Hotel> Hotels { get; set; }
    }
}
