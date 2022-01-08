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
    [Table("Files")]
    public class _File
    {
        [Key][DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get;  set;}
        [Required]
        public string Name { get; set; }
        

        //Root is equals to Directory+Name+Extension
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string FilePath { get; set; }

        [Required]
        public string Extension { get; set; }
          
        [Required]
        public ImageType Type { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual NWEvent Event { get; set; }

        [ForeignKey(nameof(NWEvent))]
        public int EventId { get; set; }

        public _File()
        {
            //Root = @"D:\NWRoot\";
        }

    }
}
