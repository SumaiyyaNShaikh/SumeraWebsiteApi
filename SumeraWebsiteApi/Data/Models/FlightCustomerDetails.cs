using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SumeraWebsiteApi.Data.Models
{
    [Table("FlightCustomerDetails", Schema = "transaction")]
    public class FlightCustomerDetails
    {
        [Key]
        public int Id { get; set; }
        public int? FlightBookingRefId { get; set; }
        [ForeignKey(nameof(FlightBookingRefId))]

        public FlightBooking? flightBooking { get; set; } 
        public int CustomerRefId { get; set; }

        [ForeignKey(nameof(CustomerRefId))]
        public Customer? customer { get; set; } 


    }
}
