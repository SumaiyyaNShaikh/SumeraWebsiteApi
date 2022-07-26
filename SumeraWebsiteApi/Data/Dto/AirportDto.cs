namespace SumeraWebsiteApi.Data.Dto
{
    public class AirportDto
    {
        public int Id { get; set; }

        public string Code { get; set; } = null!;
        public int? CityRefId { get; set; }
       
        public string Address1 { get; set; } = null!;
       

        public string Address2 { get; set; } = null!;
       

        public string Address3 { get; set; } = null!;
        public int Pincode { get; set; }


        public string Telephone { get; set; }

     

        public string? Telephone1 { get; set; }
       

        public string Email { get; set; } = null!;
       


        public string? Email1 { get; set; }

    }
}

