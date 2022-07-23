using HolidaySearch.Data;
using HolidaySearch.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidaySearch
{
    public class HolidaySearch
    {
        
        public List<Flight> GetFlightData()
        {
            var dbContext = new OnTheBeachDbContext();
            return dbContext.Flights;

        }

        public List<Hotel> GetHotelData()
        {
            var dbContext = new OnTheBeachDbContext();
            return dbContext.Hotels;
        }
        
    }
}
