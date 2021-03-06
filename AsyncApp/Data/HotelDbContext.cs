﻿using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using AsyncApp.Models;
using System;
using Microsoft.AspNetCore.Identity;

namespace AsyncApp.Data
{
    public class HotelDbContext : IdentityDbContext<ApplicationUser>
    {
        public HotelDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Hotel>()
                .HasData(
                    new Hotel { Id = 1, Name = "Async Inn", StreetAdress = "123 Sync Street", City = "Des Moines", State = "Iowa", Phone = "515-555-1234" },
                    new Hotel { Id = 2, Name = "Async Motel", StreetAdress = "1858 Cyclone Lane", City = "Ames", State = "Iowa", Phone = "515-294-1111" },
                    new Hotel { Id = 3, Name = "Async Suites", StreetAdress = "5050 Morning Star Court", City = "Pleasant Hill", State = "Iowa", Phone = "515-299-1234" }
                );

            modelBuilder.Entity<Room>()
                .HasData(
                    new Room { Id = 1, Name = "Studio", Layout = 0 },
                    new Room { Id = 2, Name = "OneBedroom", Layout = 1 },
                    new Room { Id = 3, Name = "TwoBedroom", Layout = 2 }
                );

            modelBuilder.Entity<Amenity>()
                 .HasData(
                    new Amenity { Id = 1, Name = "WiFi" },
                    new Amenity { Id = 2, Name = "Air Conditioning" },
                    new Amenity { Id = 3, Name = "Coffee Maker" }
                );

            modelBuilder.Entity<RoomAmenity>()
                .HasKey(roomAmenity => new
                {
                    roomAmenity.AmenityId,
                    roomAmenity.RoomId
                 });

            // modelBuilder.Entity<HotelRoom>()
            //.HasKey(roomAmenity => new
            //{
            //    hotelRoom.HotelId,
            //    hotelRoom.RoomNumber
            //});

            SeedRole(modelBuilder, "District Manager");
            SeedRole(modelBuilder, "Property Manager");
            SeedRole(modelBuilder, "Agent");
        }

        private void SeedRole(ModelBuilder modelBuilder, string roleName)
        {
            var role = new IdentityRole
            {
                Id = roleName.ToLower(),
                Name = roleName,
                NormalizedName = roleName.ToUpper(),
                ConcurrencyStamp = Guid.Empty.ToString(),
            };
            modelBuilder.Entity<IdentityRole>().HasData(role);
        }

        public DbSet<Hotel> Hotels { get; set; }

        public DbSet<Room> Rooms { get; set; }

        public DbSet<Amenity> Amenities { get; set; }

        public DbSet<RoomAmenity> RoomAmenities { get; set; }

        public DbSet<HotelRoom> HotelRooms { get; set; }

    }
}
