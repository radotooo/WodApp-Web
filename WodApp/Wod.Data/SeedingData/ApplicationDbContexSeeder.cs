using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Wod.Data.SeedingData.Contracts;
using WodApp.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity;
using System.Linq;

namespace Wod.Data.SeedingData
{

    public class ApplicationDbContexSeeder 
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly ApplicationDbContext dbContext;

        public ApplicationDbContexSeeder(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            this.userManager = serviceProvider.GetService<UserManager<IdentityUser>>();
            this.roleManager = serviceProvider.GetService<RoleManager<IdentityRole>>();
            this.dbContext = dbContext;
        }
        public async Task SeedDataAsync()
        {
            await SeedUserAsync();
            await SeedRolesAsync();
            await SeedUserToRoleAsync();
        }

        private async Task SeedUserToRoleAsync()
        {
            var user = await userManager.FindByNameAsync("Rado");
            var role = await roleManager.FindByNameAsync("Admin");

            var exists = dbContext.UserRoles.Any(x => x.UserId == user.Id && x.RoleId == role.Id);

            if(exists)
            {
                return;
            }

            dbContext.UserRoles.Add(new IdentityUserRole<string>
            {
                RoleId = role.Id,
                UserId = user.Id
            });
            await dbContext.SaveChangesAsync();
        }

        private async Task SeedRolesAsync()
        {
            var role = await roleManager.FindByNameAsync("Admin");
            if (role != null)
            {
                return;
            }
            await roleManager.CreateAsync(new IdentityRole
            {
                Name = "Admin"
            });
        }

        private async Task SeedUserAsync()
        {
            var user = await userManager.FindByNameAsync("Rado");

            if (user != null)
            {
                return;
            }

           var result = await userManager.CreateAsync(new IdentityUser
            {
                UserName = "admin@admin.admin",
                Email = "admin@admin.admin",
                EmailConfirmed = true

            }, "rado1912");

            //if(!result.Succeeded)
            //{

            //}
        }
    }
}
