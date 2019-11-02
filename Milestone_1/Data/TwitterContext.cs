using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Milestone_1.models;

namespace Milestone_1.Data
{
    public class TwitterContext : DbContext
    {
        public TwitterContext(DbContextOptions options) : base(options)
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
            // one to one UserData->User
            modelBuilder.Entity<User>()
                .HasOne(p => p.UserData)
                .WithOne(i => i.User)
                .HasForeignKey<UserData>(b => b.UserForeignKey);

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
        .HasKey(bc => new { bc.UserDataId, bc.GroupId });

            modelBuilder.Entity<UserDataGroup>()
                .HasOne(pt => pt.UserData)
                .WithMany(p => p.UserDataGroups)
                .HasForeignKey(pt => pt.UserDataId);

            modelBuilder.Entity<UserDataGroup>()
                .HasOne(pt => pt.Group)
                .WithMany(t => t.UserDataGroups)
                .HasForeignKey(pt => pt.GroupId);

        }

 
    }
}
