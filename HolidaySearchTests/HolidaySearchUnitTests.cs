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

        [Test]
        public void IsHolidaySearch_Results_IsNotEmpty_Return_True()
        {
            holidaySearch = new HolidaySearch("MAN", "AGP", "2023-07-01", "7");

            var results = holidaySearch.Results();

            Assert.IsNotNull(results, "Holiday Search results are empty");
        }

        [Test]
        public void HolidaySearch_Results_Test1_Multiple_Assertions()
        {
            holidaySearch = new HolidaySearch("MAN", "AGP", "2023-07-01", "7");

            var results = holidaySearch.Results();

            Assert.IsNotNull(results, "Holiday search results are null for test 1");

            Assert.IsNotNull(results.Flights, "Holiday search flight results are empty for test 1");

            Assert.IsNotNull(results.Hotels, "Holiday search hotel results are empty for test 1");

            Assert.NotZero(results.TotalPrice, "Holiday search results total price is 0 for test 1");

            Assert.IsTrue(results.Flights.Id == 2, "Flight Id is not 6 for test 1");
            Assert.IsTrue(results.Hotels.Id == 9, "Hotel Id is not 5 for test 1");
        }
    }
}