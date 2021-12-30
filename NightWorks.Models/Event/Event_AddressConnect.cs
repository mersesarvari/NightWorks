using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightWorks.Models
{
    public class Event_AddressConnect
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int EventId { get; set; }
        public virtual Event Event { get; set; }
        public int EventAddressId { get; set; }
        public virtual Address EventAddress { get; set; }
    }
}
