using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Milestone_1.models;

namespace Milestone_1.Areas.Identity.Data
{
    public class Milestone_1IdentityDbContext : IdentityDbContext<IdentityUser>
    {
        public Milestone_1IdentityDbContext(DbContextOptions<Milestone_1IdentityDbContext> options)
            : base(options)
        {
        }

        public DbSet<Comment> comments { get; set; }
        public DbSet<Followers> followers { get; set; }
        public DbSet<Group> groups { get; set; }
        public DbSet<Tweets> tweets { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<UserData> userDatas { get; set; }
        public DbSet<UserDataGroup> userDataGroups { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole { Name = "User", NormalizedName = "USER", Id = Guid.NewGuid().ToString(), ConcurrencyStamp = Guid.NewGuid().ToString() });
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole { Name = "Admin", NormalizedName = "ADMIN", Id = Guid.NewGuid().ToString(), ConcurrencyStamp = Guid.NewGuid().ToString() });

            // one to one UserData->User
            modelBuilder.Entity<User>()
                .HasOne(p => p.UserData)
                .WithOne(i => i.User);
            //.HasForeignKey<UserData>(b => b.UserForeignKey);

            // one to many UserData->Tweets

            modelBuilder.Entity<UserData>()
                .HasMany(c => c.Tweets)
                .WithOne(e => e.UserData);
            // one to many Tweets -> Comments

            modelBuilder.Entity<Tweets>()
                .HasMany(c => c.Comments)
                .WithOne(e => e.Tweets);

            // one to many UserData->Followers

            modelBuilder.Entity<UserData>()
                .HasMany(c => c.Followers)
                .WithOne(e => e.UserData);

            // one to many Group->Tweets

            modelBuilder.Entity<Group>()
            .HasMany(c => c.Tweets)
            .WithOne(e => e.Group);


            //many to many UserData<->Group
            modelBuilder.Entity<UserDataGroup>()
            .HasKey(bc => new { bc.UserDataForeignKey, bc.GroupForeignKey });

            modelBuilder.Entity<UserDataGroup>()
                .HasOne(pt => pt.UserData)
                .WithMany(p => p.UserDataGroups)
                .HasForeignKey(pt => pt.UserDataForeignKey);

            modelBuilder.Entity<UserDataGroup>()
                .HasOne(pt => pt.Group)
                .WithMany(t => t.UserDataGroups)
                .HasForeignKey(pt => pt.GroupForeignKey);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
