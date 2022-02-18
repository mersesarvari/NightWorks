using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using NigthWorks.Models;
using NightWorks.Data;
using System.Linq;
using System;

namespace NigthWorks.Data
{
    public partial class NWDbContext : DbContext
    {

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<_File> Files { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Keyword> Keywords { get; set; }
        public virtual DbSet<NWEvent> Events { get; set; }
        public virtual DbSet<Event_Keyword_Connect> Event_Keyword_Connects { get; set; }
        public virtual DbSet<Event_User_Connect> Event_User_Connects { get; set; }
        public virtual DbSet<UserSettings_Keyword_Connect> UserSettings_Keyword_Connects { get; set; }

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

            // DeleteBehavior.NoAction mindenhova
            mb.Entity<User>(entity =>
            {
                entity.HasOne(x => x.Role)
                    .WithMany(y => y.Users)
                    .HasForeignKey(x => x.Roleid)
                    .OnDelete(DeleteBehavior.Restrict);
            });
            //User -> Posts
            mb.Entity<Post>(entity =>
            {
                entity.HasOne(x => x.User)
                    .WithMany(y => y.Posts)
                    .HasForeignKey(x => x.Post_UserId)
                    .OnDelete(DeleteBehavior.Restrict);

            });
            
            mb.Entity<NWEvent>(entity =>
            {
                entity.HasOne(x => x.User)
                    .WithMany(y => y.Events)
                    .HasForeignKey(x => x.Owner_Id)
                    .OnDelete(DeleteBehavior.Restrict);

            });
            mb.Entity<NWEvent>(entity =>
            {
                entity.HasOne(x => x.User)
                    .WithMany(y => y.Events)
                    .HasForeignKey(x => x.Owner_Id)
                    .OnDelete(DeleteBehavior.Restrict);

            });


            mb.Entity<Event_User_Connect>().HasKey(pt => new { pt.UserId, pt.EventId });
            mb.Entity<Event_User_Connect>().HasOne(y => y.User).WithMany(y => y.Event_User_Conns).HasForeignKey(y => y.UserId).OnDelete(DeleteBehavior.Restrict);
            mb.Entity<Event_User_Connect>().HasOne(x => x.Event).WithMany(x => x.Event_User_Conns).HasForeignKey(x => x.EventId).OnDelete(DeleteBehavior.Restrict);


            mb.Entity<Event_Keyword_Connect>().HasKey(pt => new { pt.FK_KeywordId, pt.FK_EventId });
            mb.Entity<Event_Keyword_Connect>().HasOne(y => y.Keyword).WithMany(y => y.Event_Keyword_Conns).HasForeignKey(y => y.FK_KeywordId).OnDelete(DeleteBehavior.Restrict);
            mb.Entity<Event_Keyword_Connect>().HasOne(x => x.Event).WithMany(x => x.Event_Keyword_Conns).HasForeignKey(x => x.FK_EventId).OnDelete(DeleteBehavior.Restrict);

            
            mb.Entity<UserSettings_Keyword_Connect>().HasKey(pt => new { pt.FK_KeywordId, pt.FK_UserSettingsId });
            mb.Entity<UserSettings_Keyword_Connect>().HasOne(y => y.UserSettings).WithMany(y => y.UserSettings_Keyword_Conns).HasForeignKey(y => y.FK_UserSettingsId).OnDelete(DeleteBehavior.Restrict);
            mb.Entity<UserSettings_Keyword_Connect>().HasOne(x => x.Keyword).WithMany(x => x.UserSettings_Keyword_Conns).HasForeignKey(x => x.FK_KeywordId).OnDelete(DeleteBehavior.Restrict);
            
            RoleDBSeed.LoadData(mb);
            UserDBSeed.LoadData(mb);
            /*
            PostDBSeed.LoadData(mb);            
            AddressDBSeed.LoadData(mb);
            EventDBSeed.LoadData(mb);
            KeywordDBSeed.LoadData(mb);
            UserSettingsDBSeed.LoadData(mb);
            Event_User_ConnectDBSeed.LoadData(mb);
            Event_Keyword_ConnectDBSeed.LoadData(mb);
            UserSettings_Keyword_ConnectDBSeed.LoadData(mb);
            */




        }
    }
}
