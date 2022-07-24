using HolidaySearchOTB.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidaySearchOTB.Interface
{
    public abstract class SearchMyHoliday
    {
        public string departingFrom { get; set; }
        public string travelingTo { get; set; }
        public string departureDate { get; set; }
        public string duration { get; set; }
        public OnTheBeachDbContext dbContext { get; set; }


        public SearchMyHoliday(string DepartingFrom, string TravelingTo, string DepartureDate, string Duration)
        {
            departingFrom = DepartingFrom;
            travelingTo = TravelingTo;
            departureDate = DepartureDate;
            duration = Duration;
            dbContext = new OnTheBeachDbContext();
        }

        public abstract double CalculateTotalPrice(double flightPrice, double hotelPrice, int noOfNights);

    }
}
