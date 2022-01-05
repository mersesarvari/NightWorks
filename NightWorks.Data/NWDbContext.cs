using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using NigthWorks.Models;
using NightWorks.Models;
using NightWorks.Data;

namespace NigthWorks.Data
{
    public partial class NWDbContext : DbContext
    {

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<EventMainImage> EventMainImages { get; set; }

        //Alap
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Keyword> Keywords { get; set; }
        public virtual DbSet<NWEvent> Events { get; set; }
        public virtual DbSet<Event_Keyword_Connect> Event_Keyword_Connects { get; set; }
        public virtual DbSet<Event_User_Connect> Event_User_Connects { get; set; }

        public NWDbContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                string conn =
                    @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database\NWData.mdf;Integrated Security=True;MultipleActiveResultSets=true";
                builder
                    .UseLazyLoadingProxies()
                    .UseSqlServer(conn);
            }
        }

        protected override void OnModelCreating(ModelBuilder mb)
        {

            //Identitás checkek:
            mb.Entity<User>().HasIndex(X => X.Email).IsUnique();
            mb.Entity<Role>().HasIndex(X => X.Name).IsUnique();


            mb.Entity<NWEvent>()
                .HasOne(a => a.)
                .WithOne(b => b.Author)
                .HasForeignKey<AuthorBiography>(b => b.AuthorRef);

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
                    .HasForeignKey(x => x.Post_UserId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
            mb.Entity<NWEvent>(entity =>
            {
                entity.HasOne(x => x.Address)
                    .WithMany(y => y.Events)
                    .HasForeignKey(x => x.Address_Id)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            //Alap
            //Event <--> User
            mb.Entity<Event_User_Connect>().HasKey(pt => new { pt.UserId, pt.EventId });
            mb.Entity<Event_User_Connect>().HasOne(y => y.User).WithMany(y => y.EUserConns).HasForeignKey(y => y.UserId).OnDelete(DeleteBehavior.NoAction);
            mb.Entity<Event_User_Connect>().HasOne(x => x.Event).WithMany(x => x.EUserConns).HasForeignKey(x => x.EventId).OnDelete(DeleteBehavior.NoAction);

            //Event <--> EventType
            mb.Entity<Event_Keyword_Connect>().HasKey(pt => new { pt.KeywordId, pt.EventId });
            mb.Entity<Event_Keyword_Connect>().HasOne(y => y.Keyword).WithMany(y => y.EKeywordConns).HasForeignKey(y => y.KeywordId).OnDelete(DeleteBehavior.NoAction);
            mb.Entity<Event_Keyword_Connect>().HasOne(x => x.Event).WithMany(x => x.EKeywordConns).HasForeignKey(x => x.EventId).OnDelete(DeleteBehavior.NoAction);

           

            EventDBSeed.LoadData(mb);
            UserDBSeed.LoadData(mb);

        }
    }
}
