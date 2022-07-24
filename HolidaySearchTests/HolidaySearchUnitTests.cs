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

            Assert.IsTrue(results.Flights.Id == 2, "Flight Id is not 2 for test 1");
            Assert.IsTrue(results.Hotels.Id == 9, "Hotel Id is not 9 for test 1");
        }
        
        [Test]
        public void HolidaySearch_Results_Test2_Multiple_Assertions()
        {
            holidaySearch = new HolidaySearch("ANY", "PMI", "2023-06-15", "10");

            var results = holidaySearch.Results();

            Assert.IsNotNull(results, "Holiday search results are empty for test 2");

            Assert.IsNotNull(results.Flights, "Holiday search flight results are empty for test 2");

            Assert.IsNotNull(results.Hotels, "Holiday search hotel results are empty for test 2");

            Assert.NotZero(results.TotalPrice, "Holiday search results total price is 0 for test 2");

            Assert.IsTrue(results.Flights.Id == 6, "Flight Id is not 6 for test 2");

            Assert.IsTrue(results.Hotels.Id == 5, "Hotel Id is not 5 for test 2");
        }

        [Test]
        public void HolidaySearch_Results_Test3_Multiple_Assertions()
        {
            holidaySearch = new HolidaySearch("ANY", "LPA", "2022-11-10", "14");

            var results = holidaySearch.Results();

            Assert.IsNotNull(results, "Holiday search results are empty for test 3");

            Assert.IsNotNull(results.Flights, "Holiday search flight results are empty for test 3");

            Assert.IsNotNull(results.Hotels, "Holiday search hotel results are empty for test 3");

            Assert.NotZero(results.TotalPrice, "Holiday search results total price is 0 for test 3");

            Assert.IsTrue(results.Flights.Id == 7, "Flight Id is not 7 for test 3");

            Assert.IsTrue(results.Hotels.Id == 6, "Hotel Id is not 6 for test 3");
        }

        [Test]
        public void HolidaySearch_Test_GetListOfFlightsAndHotels()
        {
            holidaySearch = new HolidaySearch("ANY", "ANY", "ANY", "ANY");

            var results = holidaySearch.GetListOfFlightsAndHotels();

            Assert.IsNotNull(results, "Holiday search results are empty for test 4");

            Assert.IsNotNull(results.Item1, "Holiday search flight results are empty for test 4");

            Assert.IsNotNull(results.Item2, "Holiday search hotel results are empty for test 4");
        }
        
        [Test]
        public void HolidaySearch_Results_Test4_Multiple_Assertions()
        {
            holidaySearch = new HolidaySearch("ANY LONDON", "PMI", "2023-06-15", "14");

            var results = holidaySearch.Results();

            Assert.IsNotNull(results, "Holiday search results are empty for test 4");

            Assert.IsNotNull(results.Flights, "Holiday search flight results are empty for test 4");

            Assert.IsNotNull(results.Hotels, "Holiday search hotel results are empty for test 4");

            Assert.NotZero(results.TotalPrice, "Holiday search results total price is 0 for test 4");

            Assert.IsTrue(results.Flights.Id == 6, "Flight Id is not 6 for test 4");

            Assert.IsTrue(results.Hotels.Id == 3, "Hotel Id is not 3 for test 4");
        }



    }
}
