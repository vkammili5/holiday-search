using HolidaySearchOTB.Data;
using HolidaySearchOTB.Interface;
using HolidaySearchOTB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidaySearchOTB
{
    public class HolidaySearch : SearchMyHoliday
    {
        public HolidaySearch(string DepartingFrom, string TravelingTo, string DepartureDate, string Duration) :
            base(DepartingFrom, TravelingTo, DepartureDate, Duration)
        {
        }

        
        public List<Flight> GetFlightData()
        {
            //var dbContext = new OnTheBeachDbContext();

            return dbContext.Flights;
        }

        public List<Hotel> GetHotelData()
        {
            //var dbContext = new OnTheBeachDbContext();

            return dbContext.Hotels;
        }

        public Tuple<List<Flight>, List<Hotel>> GetListOfFlightsAndHotels()
        {
            List<Flight> flights = new List<Flight>();
            List<Hotel> hotels = new List<Hotel>();

            flights.AddRange(dbContext.Flights);
            hotels.AddRange(dbContext.Hotels);

            if(departingFrom.ToLower() != "any")
            {
                flights = flights.Where(p => p.From == departingFrom).ToList();
            }

            if (travelingTo.ToLower() != "any")
            {
                flights = flights.Where(p => p.To == travelingTo).ToList();
                hotels = hotels.Where(p => p.Local_Airports.Contains(travelingTo)).ToList();
            }

            if (departureDate.ToLower() != "any")
            {
                flights = flights.Where(p => p.Departure_Date == departureDate).ToList();
                hotels = hotels.Where(p => p.Arrival_Date == departureDate).ToList();
            }

            if (duration.ToLower() != "any")
            {
                hotels = hotels.Where(p => p.Nights == Convert.ToInt32(duration)).ToList();
            }

            flights = flights.OrderBy(p => p.Price).ToList();
            hotels = hotels.OrderBy(p => p.Price_Per_Night).ToList();

            return Tuple.Create(flights, hotels);


        }
    }
}
