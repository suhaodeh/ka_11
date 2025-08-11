using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KASHOP.DAL.Data;
using KASHOP.DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace KASHOP.DAL.Utilities
{

    public class SeedData : ISeedData
    {
        private readonly ApplicationDbContext _context;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public SeedData(ApplicationDbContext context,
            RoleManager<IdentityRole> roleManager,
            UserManager<ApplicationUser> userManager
            )
        {
            _context = context;
            _roleManager = roleManager;
            _userManager = userManager;
        }
        public async Task DataSeedingAsync()
        {
            if ((await _context.Database.GetPendingMigrationsAsync()).Any())
            {
                await _context.Database.MigrateAsync();

            }
            if (!await _context.Categories.AnyAsync())
            {
                await _context.Categories.AddRangeAsync(
                     new Category { Name = "Clothes" },
                     new Category { Name = "Mobiles" }

                     );

            }
            if (!await _context.Brands.AnyAsync())
            {
                await _context.Brands.AddRangeAsync(
                     new Brand { Name = "Nike" },
                       new Brand { Name = "Apple" },
                       new Brand { Name = "Puma" }
                     );
            }
            await _context.SaveChangesAsync();
        }



        public async Task IdentityDataSeedingAsync()
        {
            if (!await _roleManager.Roles.AnyAsync())
            {
                await _roleManager.CreateAsync(new IdentityRole("Admin"));
                await _roleManager.CreateAsync(new IdentityRole("SuperAdmin"));
                await _roleManager.CreateAsync(new IdentityRole("Customer"));
            }
            if (!await _userManager.Users.AnyAsync())
            {
                var user1 = new ApplicationUser()
                {
                    Email = "tariq@gmail.com",
                    FullName = "tariq shreem",
                    PhoneNumber = "098765432",
                    UserName = "tshreem",
                    EmailConfirmed=true,
                };

                var user2 = new ApplicationUser()
                {
                    Email = "suha@gmail.com",
                    FullName = "suha shreem",
                    PhoneNumber = "098712342",
                    UserName = "tssshreem",
                      EmailConfirmed = true,
                };

                var user3 = new ApplicationUser()
                {
                    Email = "maya@gmail.com",
                    FullName = "maya shreem",
                    PhoneNumber = "0987889",
                    UserName = "mshreem",
                      EmailConfirmed = true,
                };

                await _userManager.CreateAsync(user1, "Pass@1234");
                await _userManager.CreateAsync(user2, "Pass@1234");
                await _userManager.CreateAsync(user3, "Pass@1234");

                await _userManager.AddToRoleAsync(user1, "Admin");
                await _userManager.AddToRoleAsync(user2, "SuperAdmin");
                await _userManager.AddToRoleAsync(user3, "Customer");



            }

        }
    }
}