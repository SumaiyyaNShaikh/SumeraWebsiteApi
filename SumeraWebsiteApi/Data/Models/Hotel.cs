using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SumeraWebsiteApi.Data.Models
{
    [Table("Hotel", Schema = "master")]

    public class Hotel
    {
        [Key]
        public int Id { get; set; }
        [Unicode(false)]
        [StringLength(100)]
        public string Name { get; set; } = null!;
        [Unicode(false)]
        [StringLength(20)]
        public string star { get; set; } = null!;

        public int? CityRefId { get; set; }

        [ForeignKey(nameof(CityRefId))]

        public City? City { get; set; } 
    }
}


