
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SumeraWebsiteApi.Data.Models
{
    [Table("City", Schema = "master")]

    public class City
    {
        [Key]
        public int Id { get; set; }
        [Unicode(false)]
        [StringLength(100)]
        public string Name { get; set; } = null!;

        public int CountryRefId { get; set; }
        [ForeignKey(nameof(CountryRefId))]

        public Country Country { get; set; }  =null!;

    }
}
