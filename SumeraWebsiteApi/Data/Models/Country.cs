using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SumeraWebsiteApi.Data.Models
{
    [Table("Country", Schema = "master")]

    public class Country
    {
        [Key]
        public int Id { get; set; }
        [Unicode(false)]
        [StringLength(20)]
        public string Code { get; set; } = null!;
        [Unicode(false)]
        [StringLength(100)]
        public string Name { get; set; } = null!;
    }
}
