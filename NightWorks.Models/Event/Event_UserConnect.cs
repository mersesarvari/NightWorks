using NigthWorks.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightWorks.Models
{
    public class Event_UserConnect
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public  EventUserRelation Relation { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public int EventId { get; set; }
        public virtual Event Event { get; set; }
    }
}
