using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using GetPin.Data;

namespace GetPin.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20160706164139_InitialPostOfficeSchema")]
    partial class InitialPostOfficeSchema
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rc2-20896");

            modelBuilder.Entity("GetPin.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id");

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedUserName")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("GetPin.Models.Country", b =>
                {
                    b.Property<Guid>("CountryId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CountryName");

                    b.HasKey("CountryId");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("GetPin.Models.District", b =>
                {
                    b.Property<Guid>("DistrictId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DistrictName");

                    b.Property<Guid?>("StateId");

                    b.HasKey("DistrictId");

                    b.HasIndex("StateId");

                    b.ToTable("Districts");
                });

            modelBuilder.Entity("GetPin.Models.Division", b =>
                {
                    b.Property<Guid>("DivisionId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DivisionName");

                    b.Property<Guid?>("RegionId");

                    b.HasKey("DivisionId");

                    b.HasIndex("RegionId");

                    b.ToTable("Divisions");
                });

            modelBuilder.Entity("GetPin.Models.Office", b =>
                {
                    b.Property<Guid>("OfficeId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("OfficeName");

                    b.HasKey("OfficeId");

                    b.ToTable("Offices");
                });

            modelBuilder.Entity("GetPin.Models.PinCode", b =>
                {
                    b.Property<Guid>("PinCodeId")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("CountryId");

                    b.Property<string>("PinCodeNumber");

                    b.HasKey("PinCodeId");

                    b.HasIndex("CountryId");

                    b.ToTable("PinCode");
                });

            modelBuilder.Entity("GetPin.Models.PostOffice", b =>
                {
                    b.Property<Guid>("PostOfficeId")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("CircleStateId");

                    b.Property<int>("DeliveryStatus");

                    b.Property<Guid?>("DistrictId");

                    b.Property<Guid?>("DivisionId");

                    b.Property<string>("Latitude");

                    b.Property<string>("Longitude");

                    b.Property<int>("OfficeType");

                    b.Property<string>("Phone");

                    b.Property<Guid?>("PinCodeId");

                    b.Property<string>("PostOfficeName");

                    b.Property<Guid?>("RegionId");

                    b.Property<Guid?>("RelatedHeadOfficeOfficeId");

                    b.Property<Guid?>("RelatedSubOfficeOfficeId");

                    b.Property<Guid?>("StateId");

                    b.Property<Guid?>("TalukId");

                    b.HasKey("PostOfficeId");

                    b.HasIndex("CircleStateId");

                    b.HasIndex("DistrictId");

                    b.HasIndex("DivisionId");

                    b.HasIndex("PinCodeId");

                    b.HasIndex("RegionId");

                    b.HasIndex("RelatedHeadOfficeOfficeId");

                    b.HasIndex("RelatedSubOfficeOfficeId");

                    b.HasIndex("StateId");

                    b.HasIndex("TalukId");

                    b.ToTable("PostOffices");
                });

            modelBuilder.Entity("GetPin.Models.Region", b =>
                {
                    b.Property<Guid>("RegionId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("RegionName");

                    b.HasKey("RegionId");

                    b.ToTable("Regions");
                });

            modelBuilder.Entity("GetPin.Models.State", b =>
                {
                    b.Property<Guid>("StateId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("StateName");

                    b.HasKey("StateId");

                    b.ToTable("States");
                });

            modelBuilder.Entity("GetPin.Models.Taluk", b =>
                {
                    b.Property<Guid>("TalukId")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("DistrictId");

                    b.Property<string>("TalukName");

                    b.HasKey("TalukId");

                    b.HasIndex("DistrictId");

                    b.ToTable("Taluk");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("GetPin.Models.District", b =>
                {
                    b.HasOne("GetPin.Models.State")
                        .WithMany()
                        .HasForeignKey("StateId");
                });

            modelBuilder.Entity("GetPin.Models.Division", b =>
                {
                    b.HasOne("GetPin.Models.Region")
                        .WithMany()
                        .HasForeignKey("RegionId");
                });

            modelBuilder.Entity("GetPin.Models.PinCode", b =>
                {
                    b.HasOne("GetPin.Models.Country")
                        .WithMany()
                        .HasForeignKey("CountryId");
                });

            modelBuilder.Entity("GetPin.Models.PostOffice", b =>
                {
                    b.HasOne("GetPin.Models.State")
                        .WithMany()
                        .HasForeignKey("CircleStateId");

                    b.HasOne("GetPin.Models.District")
                        .WithMany()
                        .HasForeignKey("DistrictId");

                    b.HasOne("GetPin.Models.Division")
                        .WithMany()
                        .HasForeignKey("DivisionId");

                    b.HasOne("GetPin.Models.PinCode")
                        .WithMany()
                        .HasForeignKey("PinCodeId");

                    b.HasOne("GetPin.Models.Region")
                        .WithMany()
                        .HasForeignKey("RegionId");

                    b.HasOne("GetPin.Models.Office")
                        .WithMany()
                        .HasForeignKey("RelatedHeadOfficeOfficeId");

                    b.HasOne("GetPin.Models.Office")
                        .WithMany()
                        .HasForeignKey("RelatedSubOfficeOfficeId");

                    b.HasOne("GetPin.Models.State")
                        .WithMany()
                        .HasForeignKey("StateId");

                    b.HasOne("GetPin.Models.Taluk")
                        .WithMany()
                        .HasForeignKey("TalukId");
                });

            modelBuilder.Entity("GetPin.Models.Taluk", b =>
                {
                    b.HasOne("GetPin.Models.District")
                        .WithMany()
                        .HasForeignKey("DistrictId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("GetPin.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("GetPin.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GetPin.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
