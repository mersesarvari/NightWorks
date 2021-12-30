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
        public virtual DbSet<Event_Type> Types { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<Event_AddressConnect> Event_AddressConnects { get; set; }
        public virtual DbSet<Event_TypeConnect> Event_TypeConnects { get; set; }
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
                    @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\NWData.mdf;Integrated Security=True";
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

            //Alap
            //Event <--> User
            mb.Entity<Event_UserConnect>().HasKey(pt => new { pt.UserId, pt.EventId });
            mb.Entity<Event_UserConnect>().HasOne(y => y.User).WithMany(y => y.EUserConns).HasForeignKey(y => y.UserId).OnDelete(DeleteBehavior.Cascade);
            mb.Entity<Event_UserConnect>().HasOne(x => x.Event).WithMany(x => x.EUserConns).HasForeignKey(x => x.EventId).OnDelete(DeleteBehavior.Cascade);

            //Event <--> EventType
            mb.Entity<Event_TypeConnect>().HasKey(pt => new { pt.TypeId, pt.EventId });
            mb.Entity<Event_TypeConnect>().HasOne(y => y.EventType).WithMany(y => y.ETConns).HasForeignKey(y => y.TypeId).OnDelete(DeleteBehavior.Cascade);
            mb.Entity<Event_TypeConnect>().HasOne(x => x.Event).WithMany(x => x.ETConns).HasForeignKey(x => x.EventId).OnDelete(DeleteBehavior.Cascade);

            //Event <--> EventAddress
            mb.Entity<Event_AddressConnect>().HasKey(pt => new { pt.AddressId, pt.EventId });
            mb.Entity<Event_AddressConnect>().HasOne(y => y.Event).WithMany(y => y.EAddressConns).HasForeignKey(y => y.EventId).OnDelete(DeleteBehavior.Cascade); ;
            mb.Entity<Event_AddressConnect>().HasOne(x => x.EventAddress).WithMany(x => x.EAddressConns).HasForeignKey(x => x.AddressId).OnDelete(DeleteBehavior.Cascade);

            EventDBSeed.LoadData(mb);
            UserDBSeed.LoadData(mb);

        }
    }
}
