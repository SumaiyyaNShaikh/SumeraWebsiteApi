using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SumeraWebsiteApi.Data.Models
{
    [Table("Flight", Schema = "master")]

    public class Flight
    {
        [Key]
        public int Id { get; set; }
        public string Code { get; set; } = null!;

        public int? AirlineRefId { get; set; }
        [ForeignKey(nameof(AirlineRefId))]
        public Airline? airline { get; set; }
        public int? FromAirportRefId { get; set; }
        [ForeignKey(nameof(FromAirportRefId))]
       public Airport? fromAirport { get; set; }


        public int? ToAirportRefId { get; set; }
        [ForeignKey(nameof(ToAirportRefId))]
       public Airport? toAirport { get; set; } 

        [Unicode(false)]
        [StringLength(100)]
        public string Address1 { get; set; } = null!;
        [Unicode(false)]
        [StringLength(100)]
        public string Address2 { get; set; } = null!;
        [Unicode(false)]
        [StringLength(100)]
        public string Address3 { get; set; } = null!;
        public int? CityRefId { get; set; } 
        [ForeignKey(nameof(CityRefId))]
        public City? City { get; set; } 
        public int Pincode { get; set; }
        [StringLength(12)]
        public string Telephone { get; set; } = null!;
        [StringLength(12)]
        public string Telephone1 { get; set; } = null!;

        [Unicode(false)]
        [StringLength(30)]
        public string Email { get; set; } = null!;
        [Unicode(false)]
        [StringLength(30)]
        public string? Email1 { get; set; }





    }
}
