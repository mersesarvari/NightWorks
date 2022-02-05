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
    [Table("Event_Keyword_Connect")]
    public class Event_Keyword_Connect
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        

        [NotMapped]
        [JsonIgnore]
        public virtual NWEvent Event { get; set; }

        [ForeignKey(nameof(Event))]
        public int FK_EventId { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual Keyword Keyword { get; set; }

        [ForeignKey(nameof(Keyword))]
        public int FK_KeywordId { get; set; }

        
    }
}
