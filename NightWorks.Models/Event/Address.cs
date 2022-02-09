using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NigthWorks.Models
{
    [Table("Address")]
    public class Address
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AddressId { get; set; }

        [Required]//x Coordinate
        public double Latitude { get; set; }
        [Required]//Y Coordinate
        public double Longitude { get; set; }

        [Required]
        public string FormattedAddress { get; set; }

        //public virtual List<NWEvent> Events { get; set; }
        public virtual NWEvent Event { get; set; }
    }
}
