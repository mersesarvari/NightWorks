using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace NigthWorks.Models
{

    public class Post
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Data { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual User User { get; set; }

        [ForeignKey(nameof(User))]
        public int Postuserid { get; set; }

    }
}

