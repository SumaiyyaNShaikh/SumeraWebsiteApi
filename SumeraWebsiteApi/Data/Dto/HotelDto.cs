namespace SumeraWebsiteApi.Data.Dto
{
    public class HotelDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string star { get; set; } = null!;

        public int CityRefId { get; set; }
    }
}
