namespace SumeraWebsiteApi.Data.Dto
{
    public class FlightSheduleDto
    {
        public int Id { get; set; }
        public int FlightRefId { get; set; }

        public DateTime DepartureDate { get; set; }
        public DateTime ArrivalDate { get; set; }
        
    }
}
