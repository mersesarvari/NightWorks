using NigthWorks.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NightWorks.Models
{
    public class Event
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(50)]
        [Required]
        public string EventName { get; set; }
        
        [Required]
        public DateTime Startingdate { get; set; }

        [Required]
        public DateTime Endingdate { get; set; }


        [MaxLength(2000)]
        [Required]
        public string EventText { get; set; }

        [NotMapped]
        [JsonIgnore] //nem volt itt
        public virtual User User { get; set; }

        [ForeignKey(nameof(User))]
        public int OwnerId { get; set; }

        public virtual List<Event_TypeConnect> ETypeConns { get; set; }

        public virtual List<Event_AddressConnect> EAddressConns { get; set; }

        public virtual List<Event_UserConnect> EUserConns { get; set; }

    }
}
