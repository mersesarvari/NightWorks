using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using NigthWorks.Models;
using NightWorks.Models;
using NightWorks.Data;

namespace NigthWorks.Data
{
    public partial class NWDbContext : DbContext
    {
        //Hozzáadott
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Post> Posts { get; set; }

        //Alap
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Keyword> Keywords { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<Event_KeywordConnect> Event_KeywordConnects { get; set; }
        public virtual DbSet<Event_UserConnect> Event_UserConnects { get; set; }

        public NWDbContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                string conn =
                    @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database\NWData.mdf;Integrated Security=True";
                builder
                    .UseLazyLoadingProxies()
                    .UseSqlServer(conn);
            }
        }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            //Hozzáadott
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
            mb.Entity<Event>(entity =>
            {
                entity.HasOne(x => x.Address)
                    .WithMany(y => y.Events)
                    .HasForeignKey(x => x.AddressId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            //Alap
            //Event <--> User
            mb.Entity<Event_UserConnect>().HasKey(pt => new { pt.UserId, pt.EventId });
            mb.Entity<Event_UserConnect>().HasOne(y => y.User).WithMany(y => y.EUserConns).HasForeignKey(y => y.UserId).OnDelete(DeleteBehavior.Cascade);
            mb.Entity<Event_UserConnect>().HasOne(x => x.Event).WithMany(x => x.EUserConns).HasForeignKey(x => x.EventId).OnDelete(DeleteBehavior.Cascade);

            //Event <--> EventType
            mb.Entity<Event_KeywordConnect>().HasKey(pt => new { pt.KeywordId, pt.EventId });
            mb.Entity<Event_KeywordConnect>().HasOne(y => y.Keyword).WithMany(y => y.EKeywordConns).HasForeignKey(y => y.KeywordId).OnDelete(DeleteBehavior.Cascade);
            mb.Entity<Event_KeywordConnect>().HasOne(x => x.Event).WithMany(x => x.EKeywordConns).HasForeignKey(x => x.EventId).OnDelete(DeleteBehavior.Cascade);

           

            EventDBSeed.LoadData(mb);
            UserDBSeed.LoadData(mb);

        }
    }
}
