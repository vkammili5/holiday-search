using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidaySearch.Interface
{
    public abstract class SearchMyHoliday
    {
        private string departingFrom { get; set; }
        private string travelingTo { get; set; }
        private string departureDate { get; set; }
        private int duration { get; set; }
        
        public SearchMyHoliday(string DepartingFrom, string TravelingTo, string DepartureDate, int Duration)
        {
            departingFrom = DepartingFrom;
            travelingTo = TravelingTo;
            departureDate = DepartureDate;
            duration = Duration;
        }

        public abstract IHolidaySearch Results();
    }
}
