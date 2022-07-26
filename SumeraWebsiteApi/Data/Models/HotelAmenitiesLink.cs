using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SumeraWebsiteApi.Data.Models
{
    [Table("HotelAmenitiesLink", Schema = "master")]
    public class HotelAmenitiesLink
    {
        [Key]
        public int Id { get; set; }

        public int? HotelRefId { get; set; }
        [ForeignKey(nameof(HotelRefId))]
        public Hotel? hotel { get; set; } 
        
        public int? AmenitiesRefId { get; set; }
        [ForeignKey(nameof(AmenitiesRefId))]
        public Amenities? amenities { get; set; } 
    }
}
