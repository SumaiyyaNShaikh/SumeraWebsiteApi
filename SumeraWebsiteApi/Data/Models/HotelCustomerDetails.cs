using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SumeraWebsiteApi.Data.Models
{
    [Table("HotelCustomerDetails", Schema = "transaction")]
    public class HotelCustomerDetails
    {
        [Key]
        public int Id { get; set; }
        public int? HotelBookingRefId { get; set; }
        [ForeignKey(nameof(HotelBookingRefId))]
        public HotelBooking? HotelBooking { get; set; } 
        public int? CustomerRefId { get; set; }
        [ForeignKey(nameof(CustomerRefId))]

        public Customer? Customer { get; set; }


    }
}
