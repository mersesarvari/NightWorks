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
    [Table("Eventmainimage")]
    public class EventMainImage
    {
        [Key][DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public byte[] Data { get; set; }

        [NotMapped][JsonIgnore]
        public virtual NWEvent Event { get; set; }

        [ForeignKey(nameof(Event))]
        public int NWEventid { get; set; }
    }
}
