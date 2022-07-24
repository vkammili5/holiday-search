﻿using HolidaySearchOTB.Data;
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
        public HolidaySearch(string DepartingFrom, string TravelingTo, string DepartureDate, int Duration) :
            base(DepartingFrom, TravelingTo, DepartureDate, Duration)
        {
        }

        public override IHolidaySearch Results()
        {
            throw new NotImplementedException();
        }

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
