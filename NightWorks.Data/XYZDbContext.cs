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
                    .HasForeignKey(s => s.roleid)
                    .OnDelete(DeleteBehavior.NoAction);
            });
            mb.Entity<Post>(entity =>
            {
                entity.HasOne(u => u.User)
                    .WithMany(i => i.Posts)
                    .HasForeignKey(s => s.PostUserId)
                    .OnDelete(DeleteBehavior.NoAction);
            });

            Role role1 = new Role() { Id = 1, Name = "root", Permission = 100 };
            Role role2 = new Role() { Id = 2, Name = "admin", Permission = 90 };
            Role role3 = new Role() { Id = 3, Name = "moderator", Permission = 80 };
            Role role4 = new Role() { Id = 4, Name = "user", Permission = 20 };
            Role role5 = new Role() { Id = 5, Name = "guest", Permission = 10 };

            User a = new User() { Id = 1, Username = "test1", Email = "test1@test.com", Password= PasswordLogic.Encrypt("theonenazmoxking","test"),roleid=role1.Id, Money=500, Validated = false };
            User b = new User() { Id = 2, Username = "test2", Email = "test2@test.com", Password= PasswordLogic.Encrypt("theonenazmoxking", "test"), roleid = role3.Id, Money =200, Validated = false };


            

            var posts = new List<Post>()
            {
                new Post() { Id = 1, Text = "Loren Imsum1", PostUserId= a.Id},
                new Post() { Id = 2, Text = "Loren Imsum2", PostUserId=b.Id},
                new Post() { Id = 3, Text = "Loren Imsum3", PostUserId=a.Id},
                new Post() { Id = 4, Text = "Loren Imsum4", PostUserId=b.Id},
                new Post() { Id = 5, Text = "Loren Imsum5", PostUserId=a.Id}
                
            };


            mb.Entity<User>().HasData(a,b);
            mb.Entity<Role>().HasData(role1,role2,role3,role4,role5);
            mb.Entity<Post>().HasData(posts);
            
            
        }
    }
}
