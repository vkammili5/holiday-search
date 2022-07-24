using HolidaySearchOTB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidaySearchOTB.Interface
{
    public interface IHolidaySearch
    {
        public List<Hotel> Hotels { get; set; }
        public List<Flight> Flights { get; set; }
        public int TotalPrice { get; set; }
    }
}
