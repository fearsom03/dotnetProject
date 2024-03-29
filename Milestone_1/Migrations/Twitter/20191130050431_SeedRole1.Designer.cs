﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Milestone_1.Data;

namespace Milestone_1.Migrations.Twitter
{
    [DbContext(typeof(TwitterContext))]
    [Migration("20191130050431_SeedRole1")]
    partial class SeedRole1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099");

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");

                    b.HasData(
                        new { Id = "ac8164ac-c458-4b15-ba8d-57e03525d9c8", ConcurrencyStamp = "ae1d2580-2261-461b-ac5b-3dcb2e6a6356", Name = "User", NormalizedName = "USER" },
                        new { Id = "eaefb4b7-4360-401d-a122-8ddb6510ac64", ConcurrencyStamp = "46d9f5e5-5806-431f-a5e8-1de717117050", Name = "Admin", NormalizedName = "ADMIN" }
                    );
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasMaxLength(128);

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Milestone_1.models.Comment", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("TweetForeignKey");

                    b.Property<int>("UserDataId");

                    b.Property<string>("commentText")
                        .IsRequired();

                    b.HasKey("id");

                    b.HasIndex("TweetForeignKey");

                    b.HasIndex("UserDataId");

                    b.ToTable("comments");
                });

            modelBuilder.Entity("Milestone_1.models.Followers", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("UserDataId");

                    b.Property<int>("UserToFollowForeignKey");

                    b.HasKey("id");

                    b.HasIndex("UserDataId");

                    b.HasIndex("UserToFollowForeignKey");

                    b.ToTable("followers");
                });

            modelBuilder.Entity("Milestone_1.models.Group", b =>
                {
                    b.Property<int>("GroupId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("discription")
                        .IsRequired();

                    b.Property<string>("name")
                        .IsRequired();

                    b.HasKey("GroupId");

                    b.ToTable("groups");
                });

            modelBuilder.Entity("Milestone_1.models.Tweets", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("GroupForeignKey");

                    b.Property<int>("UserDataForeignKey");

                    b.Property<DateTime>("post_date");

                    b.Property<string>("tweetText");

                    b.HasKey("id");

                    b.HasIndex("GroupForeignKey");

                    b.HasIndex("UserDataForeignKey");

                    b.ToTable("tweets");
                });

            modelBuilder.Entity("Milestone_1.models.User", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("login")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("password")
                        .IsRequired();

                    b.HasKey("id");

                    b.ToTable("users");
                });

            modelBuilder.Entity("Milestone_1.models.UserData", b =>
                {
                    b.Property<int>("UserDataId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("UserForeignKey");

                    b.Property<int>("birthDate");

                    b.Property<string>("city")
                        .IsRequired();

                    b.Property<string>("country")
                        .IsRequired();

                    b.Property<string>("gender")
                        .IsRequired();

                    b.Property<string>("name")
                        .IsRequired();

                    b.Property<string>("surname")
                        .IsRequired();

                    b.HasKey("UserDataId");

                    b.HasIndex("UserForeignKey")
                        .IsUnique();

                    b.ToTable("userDatas");
                });

            modelBuilder.Entity("Milestone_1.models.UserDataGroup", b =>
                {
                    b.Property<int>("UserDataForeignKey");

                    b.Property<int>("GroupForeignKey");

                    b.Property<int?>("UserForeignKey");

                    b.HasKey("UserDataForeignKey", "GroupForeignKey");

                    b.HasIndex("GroupForeignKey");

                    b.ToTable("userDataGroups");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Milestone_1.models.Comment", b =>
                {
                    b.HasOne("Milestone_1.models.Tweets", "Tweets")
                        .WithMany("Comments")
                        .HasForeignKey("TweetForeignKey")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Milestone_1.models.UserData", "UserData")
                        .WithMany()
                        .HasForeignKey("UserDataId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Milestone_1.models.Followers", b =>
                {
                    b.HasOne("Milestone_1.models.UserData", "UserData")
                        .WithMany("Followers")
                        .HasForeignKey("UserDataId");

                    b.HasOne("Milestone_1.models.User", "UserToFollow")
                        .WithMany()
                        .HasForeignKey("UserToFollowForeignKey")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Milestone_1.models.Tweets", b =>
                {
                    b.HasOne("Milestone_1.models.Group", "Group")
                        .WithMany("Tweets")
                        .HasForeignKey("GroupForeignKey")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Milestone_1.models.UserData", "UserData")
                        .WithMany("Tweets")
                        .HasForeignKey("UserDataForeignKey")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Milestone_1.models.UserData", b =>
                {
                    b.HasOne("Milestone_1.models.User", "User")
                        .WithOne("UserData")
                        .HasForeignKey("Milestone_1.models.UserData", "UserForeignKey")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Milestone_1.models.UserDataGroup", b =>
                {
                    b.HasOne("Milestone_1.models.Group", "Group")
                        .WithMany("UserDataGroups")
                        .HasForeignKey("GroupForeignKey")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Milestone_1.models.UserData", "UserData")
                        .WithMany("UserDataGroups")
                        .HasForeignKey("UserDataForeignKey")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
