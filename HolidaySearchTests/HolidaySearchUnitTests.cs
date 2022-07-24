using HolidaySearchOTB;

namespace HolidaySearchTests
{
    public class HolidaySearchUnitTests
    {
        private HolidaySearch holidaySearch;

        [SetUp]
        public void SetUp()
        {
            holidaySearch = new HolidaySearch();
        }

        [Test]
        public void IsHolidaySearch_GetFlightData_NotEmpty_True()
        {
            var flightData = holidaySearch.GetFlightData();

            Assert.IsNotNull(flightData, "Flight Data is null");
        }

        [Test]
        public void IsHolidaySearch_GetHotelData_NotEmpty_True()
        {
            var hotelData = holidaySearch.GetHotelData();

            Assert.IsNotNull(hotelData, "Hotel Data is null");
        }
    }
}