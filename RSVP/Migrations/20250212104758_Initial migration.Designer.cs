﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RSVP;

#nullable disable

namespace RSVP.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250212104758_Initial migration")]
    partial class Initialmigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RSVP.HotelReservation", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("HotelName")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfDays")
                        .HasColumnType("int");

                    b.Property<int>("SN")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("RSVP.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("ComingWithAGuest")
                        .HasColumnType("bit");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GuestNames")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfGuests")
                        .HasColumnType("int");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SN")
                        .HasColumnType("int");

                    b.Property<bool>("WillAttend")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("RSVP.HotelReservation", b =>
                {
                    b.HasOne("RSVP.User", "User")
                        .WithMany("HotelReservations")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("RSVP.User", b =>
                {
                    b.Navigation("HotelReservations");
                });
#pragma warning restore 612, 618
        }
    }
}
