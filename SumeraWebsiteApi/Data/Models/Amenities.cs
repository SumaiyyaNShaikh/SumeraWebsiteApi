﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SumeraWebsiteApi.Data.Models
{
    [Table("Amenities", Schema= "master")]
    public class Amenities
    {
        [Key]
        public int Id { get; set; }
        [Unicode(false)]
        [StringLength(100)]
        public string Name { get; set; } = null!;
        [Unicode(false)]
        [StringLength(500)]
        public string Description { get; set; } = null!;
    }
}
