using Microsoft.EntityFrameworkCore;
using NightWorks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightWorks.Data
{
    public class EventDBContext : DbContext
    {
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Event_Type> Types { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<Event_AddressConnect> Event_AddressConnects { get; set; }
        public virtual DbSet<Event_TypeConnect> Event_TypeConnects { get; set; }
        public virtual DbSet<Event_UserConnect> Event_UserConnects { get; set; }

        public EventDBContext()
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
            //Event <--> User
            mb.Entity<Event_UserConnect>().HasKey(pt => new { pt.UserId, pt.EventId });
            mb.Entity<Event_UserConnect>().HasOne(y => y.User).WithMany(y => y.EUserConns).HasForeignKey(y => y.UserId);
            mb.Entity<Event_UserConnect>().HasOne(x => x.Event).WithMany(x => x.EUserConns).HasForeignKey(x => x.EventId);

            //Event <--> EventType
            mb.Entity<Event_TypeConnect>().HasKey(pt => new { pt.TypeId, pt.EventId });
            mb.Entity<Event_TypeConnect>().HasOne(y => y.EventType).WithMany(y => y.ETConns).HasForeignKey(y => y.TypeId);
            mb.Entity<Event_TypeConnect>().HasOne(x => x.Event).WithMany(x => x.ETypeConns).HasForeignKey(x => x.EventId);

            //Event <--> EventAddress
            mb.Entity<Event_AddressConnect>().HasKey(pt => new { pt.AddressId, pt.EventId });
            mb.Entity<Event_AddressConnect>().HasOne(y => y.Event).WithMany(y => y.EAddressConns).HasForeignKey(y => y.EventId);
            mb.Entity<Event_AddressConnect>().HasOne(x => x.EventAddress).WithMany(x => x.EAddressConns).HasForeignKey(x => x.AddressId);


            EventDBSeed alpa = new EventDBSeed();
        
        





    }
    }
}
