using Entities.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Data.Identity
{
    public class AppIdentityDbContextSeed 
    {
        public static async Task SeedUsersAsync(UserManager<AppUser> userManager)
        {
            if(!userManager.Users.Any())
            {
                var user = new AppUser()
                { 
                    DisplayName = "Khalid Ali",
                    Email = "khalidAli@gmail.com",
                    UserName = "khalidAli",
                    PhoneNumber = "01023977564"
                };
                await userManager.CreateAsync(user, "Pa$$w0rdKhalid");
            }
        }
    }
}
