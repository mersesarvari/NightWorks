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
    [Table("ImageHandler")]
    public class ImageHandler
    {
        [Key][DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }
        [Required]
        public string Dataroot { get; set; }
        
        [Required]
        public string Extension { get; set; }

        
        [Required]
        public ImageType Type { get; set; }
        
        

        [NotMapped]
        [JsonIgnore] //Ez eredetileg nem volt itt
        public virtual ICollection<NWEvent> Events { get; set; }


        public ImageHandler()
        {
            Events = new List<NWEvent>();
        }
    }
}
