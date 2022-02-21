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
    [Table("User")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(15)]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Username { get; set; }

        [MaxLength(30)]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Email { get; set; }

        [MaxLength(30)]
        [Required]
        [JsonIgnore]
        public string Password { get; set; }

        public int? Money { get; set; }

        public bool Validated { get; set; }

        public string ProfilePictureRoot { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual IList<NWEvent> Events { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual Role Role { get; set; }

        [ForeignKey(nameof(Role))]
        public string Rolename { get; set; }


        [NotMapped]
        [JsonIgnore]//nem volt itt
        public virtual IList<Post> Posts { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual IList<Event_User_Connect> Event_User_Conns { get; set; }


        /*
        public string ApiString()
        {
            return $"{Id}~{Username}~{Email}~{Password}";
        }
        */


    }
}
