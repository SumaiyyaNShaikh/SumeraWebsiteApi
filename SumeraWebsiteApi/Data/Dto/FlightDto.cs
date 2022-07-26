namespace SumeraWebsiteApi.Data.Dto
{
    public class FlightDto
    {
        public int Id { get; set; }
        public string Code { get; set; } = null!;
        public int? AirlineRefId { get; set; }
        public int? FromAirportRefId { get; set; }
        public int? ToAirportRefId { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; } 
        public string Address3 { get; set; } 
        public int? CityRefId { get; set; }
        public int Pincode { get; set; }
        public string Telephone { get; set; } 
        public string Telephone1 { get; set; } 
        public string Email { get; set; } 
        public string? Email1 { get; set; }



    }
}
