using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SumeraWebsiteApi.Data.Models
{
    [Table("Customer", Schema = "master")]

    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [Unicode(false)]
        [StringLength(20)]

        public string FirstName { get; set; } = null!;
        [Unicode(false)]
        [StringLength(20)]

        public string LastName { get; set; } = null!;

        public DateTime DateOfBirth { get; set; }
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
        [StringLength(20)]
        public string Telephone { get; set; }
        [Unicode(false)]
        [StringLength(30)]
        public string Email { get; set; } = null!;


    }
}
