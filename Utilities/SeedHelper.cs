using DragonBlog.Data;
using DragonBlog.Enums;
using DragonBlog.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DragonBlog.Utilities
{
   public static class SeedHelper
    {
        public static async Task SeedDataAsync(UserManager<BlogUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            await SeedRoles(roleManager);
            await SeedAdmin(userManager);
            await SeedModerator(userManager);
        }

        private static async Task SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            await roleManager.CreateAsync(new IdentityRole(Roles.Admin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.Moderator.ToString()));
        }

        private static async Task SeedAdmin(UserManager<BlogUser> userManager)
        {
            if (await userManager.FindByEmailAsync("hollidaycodes@gmail.com") == null)
            {
                var admin = new BlogUser()
                {
                    Email = "hollidaycodes@gmail.com",
                    UserName = "hollidaycodes@gmail.com",
                    FirstName = "Jackson",
                    LastName = "Holliday",
                    DisplayName = "Jackson Holliday",
                    EmailConfirmed = true
                };

                await userManager.CreateAsync(admin, "Abc&123!");
                await userManager.AddToRoleAsync(admin, Roles.Admin.ToString());
            }
        }

        private static async Task SeedModerator(UserManager<BlogUser> userManager)
        {
                if (await userManager.FindByEmailAsync("jaxholliday@gmail.com") == null)
                {
                    var moderator = new BlogUser()
                    {
                        Email = "jaxholliday@gmail.com",
                        UserName = "jaxholliday@gmail.com",
                        FirstName = "Andrew",
                        LastName = "Holliday",
                        DisplayName = "DrewMod",
                        EmailConfirmed = true
                    };

                    await userManager.CreateAsync(moderator, "Abc&123!");
                    await userManager.AddToRoleAsync(moderator, Roles.Admin.ToString());
                }

        }
    }
}
