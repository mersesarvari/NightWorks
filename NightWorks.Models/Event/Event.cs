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
        public Event()
        {
            Creationtime = DateTime.Now;
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(50)]
        [Required]
        public string EventName { get; set; }

        public DateTime Creationtime { get; set; }

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

        [NotMapped]
        [JsonIgnore] //nem volt itt
        public virtual Address Address { get; set; }

        [ForeignKey(nameof(Address))]
        public int AddressId { get; set; }


        [NotMapped]
        [JsonIgnore]
        public virtual List<Event_KeywordConnect> EKeywordConns { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual List<Event_UserConnect> EUserConns { get; set; }

    }
}
