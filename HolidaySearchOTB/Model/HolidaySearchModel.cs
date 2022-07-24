using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidaySearchOTB.Model
{
    public class HolidaySearchModel
    {
        public Hotel Hotels { get; set; }
        public Flight Flights { get; set; }
        public double TotalPrice { get; set; }
    }
}
