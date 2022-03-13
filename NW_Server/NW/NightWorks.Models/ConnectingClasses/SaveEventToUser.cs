using NigthWorks.Models;
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
    public class SaveEventToUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int UserId { get; set; }
        [NotMapped]
        [JsonIgnore]
        public virtual User User { get; set; }
        public int EventId { get; set; }
        [NotMapped]
        [JsonIgnore]
        public virtual NWEvent Event { get; set; }
    }
}
