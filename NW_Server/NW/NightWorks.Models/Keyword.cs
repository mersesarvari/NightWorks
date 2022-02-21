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
    [Table("Keyword")]
    public class Keyword
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Name { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual IList<Event_Keyword_Connect> Event_Keyword_Conns { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual IList<UserSettings_Keyword_Connect> UserSettings_Keyword_Conns { get; set; }
    }
}
