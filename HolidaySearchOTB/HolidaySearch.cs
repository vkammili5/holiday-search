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
              return dbContext.Flights;
        }

        public List<Hotel> GetHotelData()
        {
            return dbContext.Hotels;
        }

        public Tuple<List<Flight>, List<Hotel>> GetListOfFlightsAndHotels()
        {
            List<Flight> flights = new List<Flight>();
            List<Hotel> hotels = new List<Hotel>();

            flights.AddRange(dbContext.Flights);
            hotels.AddRange(dbContext.Hotels);

            if (departingFrom.ToLower() != "any")
            {
                if (departingFrom.ToLower() == "any london")
                {
                    flights = flights.Where(p => p.From == "LGW" || p.From == "LTN").ToList();
                }
                else
                {
                    flights = flights.Where(p => p.From == departingFrom).ToList();
                }
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

        public override double CalculateTotalPrice(double flightPrice, double hotelPrice, int noOfNights)
        {
            return flightPrice + (hotelPrice * noOfNights);
        }

        public override HolidaySearchModel Results()
        {
            HolidaySearchModel results = new HolidaySearchModel();
            if(dbContext.Flights != null && dbContext.Hotels != null)
            {
                var flightsAndHotels = GetListOfFlightsAndHotels();

                if(flightsAndHotels != null)
                {
                    results.Flights = flightsAndHotels.Item1 != null ? flightsAndHotels.Item1.FirstOrDefault() : null;

                    
                    results.Hotels = flightsAndHotels.Item2?.FirstOrDefault();

                }
                if (results.Flights != null && results.Hotels != null)
                {
                    results.TotalPrice = CalculateTotalPrice(results.Flights.Price, results.Hotels.Price_Per_Night, results.Hotels.Nights);
                }
            }
            return results;
        }
    }
}
