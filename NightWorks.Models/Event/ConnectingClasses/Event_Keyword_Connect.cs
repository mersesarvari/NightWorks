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
    [Table("Event_Keyword_Connect")]
    public class Event_Keyword_Connect
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int EventId { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual NWEvent Event { get; set; }
        public int KeywordId { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual Keyword Keyword { get; set; }
    }
}
