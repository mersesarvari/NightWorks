﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NightWorks.Models
{
    public class Address
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public int PostalCode { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public int BuildingNumber { get; set; }


        [NotMapped]
        [JsonIgnore] //Ez eredetileg nem volt itt
        public virtual ICollection<Event> Events { get; set; }

        public Address()
        {
            Events = new HashSet<Event>();
        }
    }
}
