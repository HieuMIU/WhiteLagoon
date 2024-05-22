using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhiteLagoon.Application.Common.Interfaces;
using WhiteLagoon.Application.Common.Utility;
using WhiteLagoon.Domain.Entities;

namespace WhiteLagoon.Infrastructure.Data
{
    public class DbInitializer : IDbInitializer
    {
        private readonly ApplicationDbContext _db;

        private readonly RoleManager<IdentityRole> _roleManager;

        private readonly UserManager<ApplicationUser> _userManager;

        public DbInitializer(ApplicationDbContext db, RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            _db = db;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public void Initialize()
        {
            try
            {
                if (_db.Database.GetPendingMigrations().Count() > 0)
                {
                    _db.Database.Migrate();
                }

                if(!_roleManager.RoleExistsAsync(SD.Role_Admin).GetAwaiter().GetResult())
                {
                    _roleManager.CreateAsync(new IdentityRole(SD.Role_Admin)).Wait();
                    _roleManager.CreateAsync(new IdentityRole(SD.Role_Customer)).Wait();

                    _userManager.CreateAsync(new ApplicationUser
                    {
                        UserName = "admin@gmail.com",
                        Email = "admin@gmail.com",
                        Name = "Hugh Tran",
                        NormalizedUserName = "ADMIN@GMAIL.COM",
                        NormalizedEmail = "ADMIN@GMAIL.COM",
                        PhoneNumber = "641222222",
                    }, "Admin123@").GetAwaiter().GetResult();

                    ApplicationUser user = _db.ApplicationUsers.FirstOrDefault(u => u.Email == "admin@gmail.com");
                    _userManager.AddToRoleAsync(user, SD.Role_Admin);
                }  
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
