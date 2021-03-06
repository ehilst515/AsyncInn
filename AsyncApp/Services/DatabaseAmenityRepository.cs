﻿using AsyncApp.Data;
using AsyncApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncApp.Services
{
    public interface IAmenityRepository
    {
        Task<IEnumerable<Amenity>> GetAllAmenities();
        Task<bool> UpdateAmenity(Amenity amenity);
        Task<Amenity> GetAmenity (long id);
        Task CreateAmenity(Amenity amenity);
        
        Task<Amenity> DeleteOneAmenityById(long id);
    }

    public class DatabaseAmenityRepository : IAmenityRepository
    {
        private readonly HotelDbContext _context;

        public DatabaseAmenityRepository(HotelDbContext context)
        {
            _context = context;
        }

        public async Task CreateAmenity(Amenity amenity)
        {
            _context.Amenities.Add(amenity);
            await _context.SaveChangesAsync();
        }

        public async Task<Amenity> DeleteOneAmenityById(long id)
        {
            var amenity = await _context.Amenities.FindAsync(id);

            if (amenity == null)
            {
                return null;
            }

            _context.Amenities.Remove(amenity);
            await _context.SaveChangesAsync();

            return amenity;
        }

        public async Task<IEnumerable<Amenity>> GetAllAmenities()
        {
            return await _context.Amenities.ToListAsync();
        }

        public async Task<Amenity> GetAmenity(long id)
        { 
            var amenity = await _context.Amenities.FindAsync(id); return amenity;
        }

        public async Task<bool> UpdateAmenity(Amenity amenity)
        {
            _context.Entry(amenity).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await AmenityExistsAsync((int)amenity.Id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
            return true;
        }

        private async Task<bool> AmenityExistsAsync(int id)
        {
            return await _context.Amenities.AnyAsync(e => e.Id == id);
        }


    }


}
