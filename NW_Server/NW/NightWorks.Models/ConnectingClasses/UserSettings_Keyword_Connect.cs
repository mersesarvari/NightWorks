using NightWorks.Models;
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
    [Table("UserSettings_Keyword_Connect")]
    public class UserSettings_Keyword_Connect
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        public virtual UserSettings UserSettings { get; set; }
        public int FK_UserSettingsId { get; set; }

        public virtual Keyword Keyword { get; set; }
        public int FK_KeywordId { get; set; }

        
    }
}
