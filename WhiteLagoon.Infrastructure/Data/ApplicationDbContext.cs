using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhiteLagoon.Domain.Entities;

namespace WhiteLagoon.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Villa> Villas { get; set; }

        public DbSet<VillaNumber> VillaNumbers { get; set; }

        public DbSet<Amenity> Amenities { get; set; }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Villa>().HasData(
                new Villa
                {
                    Id = 1,
                    Name = "Villa A",
                    Description = "Beautiful villa with ocean view",
                    Price = 500000,
                    Sqft = 3000,
                    Occupancy = 8,
                    ImageUrl = "https://example.com/image1.jpg",
                    Created_Date = DateTime.Now,
                    Updated_Date = DateTime.Now
                },
                new Villa
                {
                    Id = 2,
                    Name = "Villa B",
                    Description = "Cozy villa nestled in the mountains",
                    Price = 400000,
                    Sqft = 2500,
                    Occupancy = 6,
                    ImageUrl = "https://example.com/image2.jpg",
                    Created_Date = DateTime.Now,
                    Updated_Date = DateTime.Now
                },
                new Villa
                {
                    Id = 3,
                    Name = "Villa C",
                    Description = "Luxurious villa with private pool",
                    Price = 800000,
                    Sqft = 4000,
                    Occupancy = 10,
                    ImageUrl = "https://example.com/image3.jpg",
                    Created_Date = DateTime.Now,
                    Updated_Date = DateTime.Now
                });
            modelBuilder.Entity<VillaNumber>().HasData(
                new VillaNumber()
                {
                    VillaId = 1,
                    Villa_Number = 101
                },
                new VillaNumber()
                {
                    VillaId = 1,
                    Villa_Number = 102
                },
                new VillaNumber()
                {
                    VillaId = 1,
                    Villa_Number = 201
                },
                new VillaNumber()
                {
                    VillaId = 2,
                    Villa_Number = 111
                },
                new VillaNumber()
                {
                    VillaId = 2,
                    Villa_Number = 112
                },
                new VillaNumber()
                {
                    VillaId = 3,
                    Villa_Number = 301
                },
                new VillaNumber()
                {
                    VillaId = 3,
                    Villa_Number = 302
                });
        }
    }
}
