namespace SumeraWebsiteApi.Data.Dto
{
    public class FlightBookingDto
    {
        public int FromAirportRefId { get; set; }
        public int? ToAirportRefId { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime ArrivalDate { get; set; }

    }
}
