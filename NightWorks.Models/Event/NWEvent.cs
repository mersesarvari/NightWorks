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
    [Table("Event")]
    public class NWEvent
    {
        public NWEvent()
        {
            Creationtime = DateTime.Now;
        }

        [Key][DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(50)][Required]
        public string EventName { get; set; }

        public DateTime Creationtime { get; set; }

        [Required]
        public DateTime Startingdate { get; set; }

        [Required]
        public DateTime Endingdate { get; set; }

        [MaxLength(2000)][Required]
        public string EventText { get; set; }

        [NotMapped]
        [JsonIgnore] //nem volt itt
        public virtual EventMainImage EventMainImage { get; set; }

        [ForeignKey(nameof(EventMainImage))]
        public int EventMainImage_Id { get; set; }

        [NotMapped]
        [JsonIgnore] //nem volt itt
        public virtual User User { get; set; }

        [ForeignKey(nameof(User))]
        public int Owner_Id { get; set; }

        public virtual Address Address { get; set; }

        [ForeignKey(nameof(Address))]
        public int Address_Id { get; set; }

        [NotMapped]
        [JsonIgnore] //nem volt itt
        public virtual List<Event_Keyword_Connect> EKeywordConns { get; set; }

        [NotMapped]
        [JsonIgnore] //nem volt itt
        public virtual List<Event_User_Connect> EUserConns { get; set; }

    }
}
