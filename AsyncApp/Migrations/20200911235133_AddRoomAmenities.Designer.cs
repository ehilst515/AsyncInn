﻿// <auto-generated />
using AsyncApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AsyncApp.Migrations
{
    [DbContext(typeof(HotelDbContext))]
    [Migration("20200911235133_AddRoomAmenities")]
    partial class AddRoomAmenities
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AsyncApp.Models.Amenity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Amenity");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Name = "WiFi"
                        },
                        new
                        {
                            Id = 2L,
                            Name = "Air Conditioning"
                        },
                        new
                        {
                            Id = 3L,
                            Name = "Coffee Maker"
                        });
                });

            modelBuilder.Entity("AsyncApp.Models.Hotel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreetAdress")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Hotel");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            City = "Des Moines",
                            Name = "Async Inn",
                            Phone = "515-555-1234",
                            State = "Iowa",
                            StreetAdress = "123 Sync Street"
                        },
                        new
                        {
                            Id = 2L,
                            City = "Ames",
                            Name = "Async Motel",
                            Phone = "515-294-1111",
                            State = "Iowa",
                            StreetAdress = "1858 Cyclone Lane"
                        },
                        new
                        {
                            Id = 3L,
                            City = "Pleasant Hill",
                            Name = "Async Suites",
                            Phone = "515-299-1234",
                            State = "Iowa",
                            StreetAdress = "5050 Morning Star Court"
                        });
                });

            modelBuilder.Entity("AsyncApp.Models.Room", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Layout")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Room");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Layout = 0,
                            Name = "Studio"
                        },
                        new
                        {
                            Id = 2L,
                            Layout = 1,
                            Name = "OneBedroom"
                        },
                        new
                        {
                            Id = 3L,
                            Layout = 2,
                            Name = "TwoBedroom"
                        });
                });

            modelBuilder.Entity("AsyncApp.Models.RoomAmenity", b =>
                {
                    b.Property<long>("AmenityId")
                        .HasColumnType("bigint");

                    b.Property<long>("RoomId")
                        .HasColumnType("bigint");

                    b.HasKey("AmenityId", "RoomId");

                    b.HasIndex("RoomId");

                    b.ToTable("RoomAmenities");
                });

            modelBuilder.Entity("AsyncApp.Models.RoomAmenity", b =>
                {
                    b.HasOne("AsyncApp.Models.Amenity", "Amenity")
                        .WithMany("RoomAmenities")
                        .HasForeignKey("AmenityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AsyncApp.Models.Room", "Room")
                        .WithMany("RoomAmenities")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
