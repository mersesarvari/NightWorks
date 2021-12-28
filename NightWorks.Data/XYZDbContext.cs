using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using NigthWorks.Models;
using NightWorks.Models;

namespace NigthWorks.Data
{
    public partial class XYZDbContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        

        public XYZDbContext()
        {
            
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                string conn =
                    @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\NWData.mdf;Integrated Security=True";
                builder
                    .UseLazyLoadingProxies()
                    .UseSqlServer(conn);
            }
        }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<User>(entity =>
            {
                entity.HasOne(u => u.Role)
                    .WithMany(i => i.Users)
                    .HasForeignKey(s => s.Roleid)
                    .OnDelete(DeleteBehavior.Cascade);
            });
            mb.Entity<Post>(entity =>
            {
                entity.HasOne(u => u.User)
                    .WithMany(i => i.Posts)
                    .HasForeignKey(s => s.Postuserid)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            Role role1 = new Role() { Id = 1, Name = "root", Permission = 100 };
            Role role2 = new Role() { Id = 2, Name = "admin", Permission = 90 };
            Role role3 = new Role() { Id = 3, Name = "moderator", Permission = 80 };
            Role role4 = new Role() { Id = 4, Name = "user", Permission = 20 };
            Role role5 = new Role() { Id = 5, Name = "guest", Permission = 10 };

            //User a = new User() { Id = 1, Username = "test1", Email = "test1@test.com", Password= PasswordLogic.Encrypt("theonenazmoxking","test"),Roleid=role1.Id, Money=500, Validated = false };
            //User b = new User() { Id = 2, Username = "test2", Email = "test2@test.com", Password= PasswordLogic.Encrypt("theonenazmoxking", "test"), Roleid = role3.Id, Money =200, Validated = false };

            User a = new User() { Id = 1, Username = "test1", Email = "test1@test.com", Password= Secure.Encrypt("test"),Roleid=role1.Id, Money=500, Validated = false };
            User b = new User() { Id = 2, Username = "test2", Email = "test2@test.com", Password = Secure.Encrypt("test"), Roleid = role3.Id, Money =200, Validated = false };



            var posts = new List<Post>()
            {
                new Post() { Id = 1, Data = "Loren Imsum1", Postuserid= a.Id},
                new Post() { Id = 2, Data = "Loren Imsum2", Postuserid=b.Id},
                new Post() { Id = 3, Data = "Loren Imsum3", Postuserid=a.Id},
                new Post() { Id = 4, Data = "Loren Imsum4", Postuserid=b.Id},
                new Post() { Id = 5, Data = "Loren Imsum5", Postuserid=a.Id}
                
            };


            mb.Entity<User>().HasData(a,b);
            mb.Entity<Role>().HasData(role1,role2,role3,role4,role5);
            mb.Entity<Post>().HasData(posts);
            
            
        }
    }
}
