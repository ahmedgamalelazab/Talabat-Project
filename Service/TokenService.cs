using Entities.Identity;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public sealed class TokenService : ITokenService
    {
        public IConfiguration Configuration { get; }
        public TokenService(IConfiguration configuration)
        {
            Configuration=configuration;
        }


        public async Task<string> CreateToken(AppUser user, UserManager<AppUser> userManager)
        {
            //Private Claims (User-Defined)
            var authClaims = new List<Claim>()
            { 
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.GivenName, user.DisplayName)
            };
            var userRoles = await userManager.GetRolesAsync(user);
            // loop on each role inside user and add it like claims 
            foreach (var role in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, role));
            }
            // create secret key but install Authentication.JwtBearer and must contain key and i put it in appsetting file 
            // i inject IConfiguration cause i would arrive to appSettings file 
            // and i use Encoding for convert value configuratoin to byte[]
            var authKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JwtSettings:Key"]));
            // create token 
            var token = new JwtSecurityToken(
                    issuer: Configuration["JwtSettings:ValidIssuer"],
                    audience: Configuration["JwtSettings:ValidAudience"],
                    expires: DateTime.Now.AddDays(double.Parse(Configuration["JwtSettings:DurationInDays"])),
                    claims: authClaims,
                    // Header key and Algorithms
                    signingCredentials: new SigningCredentials(authKey, SecurityAlgorithms.HmacSha256Signature)
                );
            // return token encoded
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
