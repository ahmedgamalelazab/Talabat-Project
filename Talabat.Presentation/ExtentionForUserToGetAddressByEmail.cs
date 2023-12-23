using Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;


namespace Talabat.Presentation
{
    public static class ExtentionForUserToGetAddressByEmail
    {
        public static async Task<AppUser> FindYsreWithAddressByEmail(this UserManager<AppUser> UserManager,
            ClaimsPrincipal User)
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            var user = await UserManager.Users.Include(u => u.Address).SingleOrDefaultAsync(u => u.Email == email);
            return user;
        }
    }
}
