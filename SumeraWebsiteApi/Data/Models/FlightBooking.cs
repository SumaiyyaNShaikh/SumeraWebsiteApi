using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SumeraWebsiteApi.Data.Models
{
    [Table(" FlightBooking", Schema = "transaction")]
    public class FlightBooking
    {
        [Key]
        public int Id { get; set; }
        public string PassengerNameRecord { get; set; } = null!;

        public DateTime BookingTimeStamp { get; set; }
        
        public int? CustomerRefId { get; set; }
        [ForeignKey(nameof(CustomerRefId))]
        public Customer? customer { get; set; } 


        public int? FlightScheduleRefId { get; set; }
        [ForeignKey(nameof(FlightScheduleRefId))]
        public Flight? flight { get; set; } 
        [Unicode(false)]
        [StringLength(10)]

        public string CustomerContactMobile { get; set; } = null!;
        [Unicode(false)]
        [StringLength(30)]
        public string CustomerContactEmail { get; set; } = null!;

       // List<FlightCustomerDetails> flightCustomerDetails ;
      
    }
}
