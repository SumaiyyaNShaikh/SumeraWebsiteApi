﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SumeraWebsiteApi.Data.Models
{
    [Table("Airport", Schema = "master")]
    public class Airport
    {
        [Key]
        public int Id { get; set; }

        [Unicode(false)]
        public string Code { get; set; } = null!;
       
        public int? CityRefId { get; set; }
        [ForeignKey(nameof(CityRefId))]

        public City? City { get; set; } 
        [Unicode(false)]
        [StringLength(100)]
        public string Address1 { get; set; } = null!;
        [Unicode(false)]
        [StringLength(100)]
        public string Address2 { get; set; } = null!;
        [Unicode(false)]
        [StringLength(100)]
        public string Address3 { get; set; } = null!;
        public int Pincode { get; set; }
    
        [StringLength(12)]
        public string Telephone { get; set; }
       
        [StringLength(12)]
        public string? Telephone1 { get; set; }
        [Unicode(false)]
        [StringLength(30)]
        public string Email { get; set; } = null!;
        [Unicode(false)]
        [StringLength(30)]
        public string? Email1 { get; set; }

    }
}
