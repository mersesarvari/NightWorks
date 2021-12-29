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

        [Required]
        public DateTime Startingdate { get; set; }

        [Required]
        public DateTime Endingdate { get; set; }

        [MaxLength(50)]
        [Required]
        public string EventName { get; set; }

        [MaxLength(2000)]
        [Required]
        public string EventText { get; set; }

        [Required]
        public EventAddress Address { get; set; }

        [Required]
        [ForeignKey(nameof(User))]
        public int Ownerid { get; set; }


        [NotMapped]
        [JsonIgnore]
        public virtual ICollection<EventType> Types { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual ICollection<User> Authors { get; set; }

        public Event()
        {
            Types = new HashSet<EventType>();
            Authors = new HashSet<User>();
        }
    }
}
