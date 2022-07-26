namespace SumeraWebsiteApi.Data.Dto
{
    public class AirlineDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;
        public string ShortName { get; set; } = null!;
        public string Logo { get; set; } = null!;
      
        public string Address1 { get; set; } = null!;
        public string Address2 { get; set; } = null!;
        public string Address3 { get; set; } = null!;
        public int? CityRefId { get; set; }
        public int Pincode { get; set; }
        public string Telephone { get; set; }

        public string? Telephone1 { get; set; }

        public string Email { get; set; } = null!;



        public string? Email1 { get; set; }

    }
}

