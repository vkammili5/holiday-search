namespace HolidaySearchTests
{
    public class HolidaySearchUnitTests
    {
        private HolidaySearch holidaySearch;

        [SetUp]
        public void Setup()
        {
            holidaySearch = new HolidaySearch();
        }

        [Test]
        public void IsHolidaySearch_GetFlightData_NotEmpty_Return_True()
        {
            var flightData = holidaySearch.GetflightData();
            Assert.IsNotNull(flightData, "Flight Data is null");
        }
    }
}