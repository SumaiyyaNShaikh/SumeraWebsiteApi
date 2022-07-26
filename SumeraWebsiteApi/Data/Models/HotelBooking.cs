using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SumeraWebsiteApi.Data.Models
{
    [Table("HotelBooking", Schema = "transaction")]
    public class HotelBooking
    {
        [Key]
        public int Id { get; set; }
        public int? HotelRefId { get; set; }
        [ForeignKey(nameof(HotelRefId))]
        public Hotel? hotel { get; set; }
        public string ConfirmationCode { get; set; } = null!;
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }

        //List<HotelCustomerDetails> HotelCustomerDetails;
    }
}
