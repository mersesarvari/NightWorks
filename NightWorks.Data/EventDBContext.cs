using Microsoft.EntityFrameworkCore;
using NightWorks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightWorks.Data
{
    public class EventDBContext:DbContext
    {


            //Újak
            public virtual DbSet<Event> Events { get; set; }
            public virtual DbSet<Models.Type> EventTypes { get; set; }


            public EventDBContext(): base("EventDB-DataAnnotations")
            {

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
                //User -> Role
                mb.Entity<User>(entity =>
                {
                    entity.HasOne(x => x.Role)
                        .WithMany(y => y.Users)
                        .HasForeignKey(x => x.Roleid)
                        .OnDelete(DeleteBehavior.Cascade);
                });
                //User -> Posts
                mb.Entity<Post>(entity =>
                {
                    entity.HasOne(x => x.User)
                        .WithMany(y => y.Posts)
                        .HasForeignKey(x => x.Postuserid)
                        .OnDelete(DeleteBehavior.Cascade);
                });
                //Events <--> Eventtypes
                mb.Entity<Event>()
                    .HasMany<Models.Type>(x => x.EventTypes)
                    .WithMany(y => y.Events)
                    .Map((object cs) =>
                    {
                        cs.MapLeftKey("StudentRefId");
                        cs.MapRightKey("CourseRefId");
                        cs.ToTable("StudentCourse");
                    });
            }
        }
    
}
