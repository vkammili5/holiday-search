using HolidaySearchOTB;

namespace HolidaySearchTests
{
    public class HolidaySearchUnitTests
    {
        private HolidaySearch holidaySearch;

        [SetUp]
        public void SetUp()
        {
            //holidaySearch = new HolidaySearch();
        }

        [Test]
        public void IsHolidaySearch_GetFlightData_NotEmpty_Return_True()
        {
            var flightData = holidaySearch.GetFlightData();

            Assert.IsNotNull(flightData, "Flight Data is null");
        }

        [Test]
        public void IsHolidaySearch_GetHotelData_NotEmpty_Return_True()
        {
            var hotelData = holidaySearch.GetHotelData();

            Assert.IsNotNull(hotelData, "Hotel Data is null");
        }

        [Test]
        public void IsHolidaySearch_GetFlightData_NotEmpty_Return_Correct_Result()
        {
            holidaySearch = new HolidaySearch("MAN", "AGP", "2023/07/01", "7");

            var flightData = holidaySearch.GetFlightData();

            Assert.IsNotNull(flightData, "Flight Data is null");
        }
        [Test]
        public void IsHolidaySearch_GetHotelData_NotEmpty_Correct_Result()
        {
            holidaySearch = new HolidaySearch("MAN", "AGP", "2023/07/01", "7");

            var hotelData = holidaySearch.GetHotelData();

            Assert.IsNotNull(hotelData, "Hotel Data is null");
        }

        [Test]
        public void IsHolidaySearch_Results_IsEmpty_Return_True()
        {
            holidaySearch = new HolidaySearch("ABC", "EFG", "2023/07/01", "7");

            var results = holidaySearch.Results();

            Assert.IsNotNull(results, "Holiday search results are null");

            Assert.IsNull(results.Flights, "Holiday search flight results are not null");

            Assert.IsNull(results.Hotels, "Holiday search hotel results are not null");
        }



    }
}