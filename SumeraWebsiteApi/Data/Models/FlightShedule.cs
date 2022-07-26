using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SumeraWebsiteApi.Data.Models
{
    [Table("FlightShedule", Schema = "transaction")]
    public class FlightShedule
    {
        [Key]
        public int Id { get; set; }
        public int? FlightRefId { get; set; }

        [ForeignKey(nameof(FlightRefId))]
        public Flight? Flight { get; set; } 
        public DateTime DepartureDate { get; set; }
        public DateTime ArrivalDate { get; set; }
        


    }
}
