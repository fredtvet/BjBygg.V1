using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Identity
{
    public class AppIdentityDbContextSeed
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync("Ansatt").Result)
                await roleManager.CreateAsync(new IdentityRole { Name = "Ansatt" });

            if (!roleManager.RoleExistsAsync("Mellomleder").Result)
                await roleManager.CreateAsync(new IdentityRole { Name = "Mellomleder" });

            if (!roleManager.RoleExistsAsync("Leder").Result)
                await roleManager.CreateAsync(new IdentityRole { Name = "Leder" });


            if (userManager.FindByNameAsync("leder").Result == null)
            {
                var user = new ApplicationUser { UserName = "kbtv", FirstName = "Karl Brede", LastName = "Tvete" };
                var result = await userManager.CreateAsync(user, "qxLpo04");

                if (result.Succeeded)
                    userManager.AddToRoleAsync(user, "Leder").Wait();
            }

            //if (userManager.FindByNameAsync("ansatt").Result == null)
            //{
            //    var user = new ApplicationUser { UserName = "ansatt", Email = "test@test.com", FirstName = "Jens", LastName = "Nordmann", PhoneNumber = "94446434" };
            //    var result = await userManager.CreateAsync(user, "passord1");

            //    if (result.Succeeded)
            //        userManager.AddToRoleAsync(user, "Ansatt").Wait();
            //}

            //if (userManager.FindByNameAsync("mellomleder").Result == null)
            //{
            //    var user = new ApplicationUser { UserName = "mellomleder", Email = "test@test.com", FirstName = "Karin", LastName = "Kro", PhoneNumber = "94446434" };
            //    var result = await userManager.CreateAsync(user, "passord1");

            //    if (result.Succeeded)
            //        userManager.AddToRoleAsync(user, "Mellomleder").Wait();
            //}

        }
    }
}

