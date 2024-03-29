﻿using NightWorks.Models;
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
    [Table("Event")]
    public class NWEvent
    {
        public NWEvent()
        {
            Creationtime = DateTime.Now;
            //Files = new HashSet<_File>();
        }
        #region Normal fields
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


        #endregion
        
        public virtual User User { get; set; }

        [ForeignKey(nameof(User))]
        public int Owner_Id { get; set; }

        public string CoverPhoto { get; set; }

        public string IconPhoto { get; set; }
        public virtual Address Address { get; set; }

        [ForeignKey(nameof(Address))]
        public int Address_Id { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual IList<Event_Keyword_Connect> Event_Keyword_Conns { get; set; }
        [NotMapped]
        [JsonIgnore]
        public virtual IList<Event_User_Connect> Event_User_Conns { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual IList<SaveEventToUser> SavedUsers { get; set; }

        public virtual IList<_File> Images { get; set; }

    }
}
