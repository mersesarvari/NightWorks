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
        public int Id { get; private set;}
        [Required]
        public string Name { get; set; }
        [Required]
        public string Root { get; set; }

        [Required]
        public string Directory { get; set; }
        [Required]
        public string Extension { get; set; }

        [Required]
        public double Size { get; set; }   
        
        [Required]
        public ImageType Type { get; set; }
        
    }
}
