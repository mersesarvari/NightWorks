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
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(15)]
        [Required]
        public string Username { get; set; }

        [MaxLength(30)]
        [Required]
        public string Email { get; set; }

        [MaxLength(30)]
        [Required]
        public string Password { get; set; }
        public int? Money { get; set; }

        public bool Validated { get; set; }
        
        [NotMapped]
        [JsonIgnore] //nem volt itt
        public virtual Role Role { get; set; }

        [ForeignKey(nameof(Role))]
        public int Roleid { get; set; }
        [NotMapped]
        [JsonIgnore]//nem volt itt
        public virtual ICollection<Post> Posts { get; set; }

        public User()
        {
            Posts = new HashSet<Post>();
        }


    }
}
