using AutoMapper;
using Entities.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransfierObject;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Talabat.Presentation.Controllers
{
    [ApiController]
    [Route("api/account")]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;

        public AccountController(UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            ITokenService  tokenService,
            IMapper mapper)
            
        {
            _userManager=userManager;
            _signInManager=signInManager;
            _tokenService=tokenService;
            _mapper=mapper;
        }

        [HttpPost("login")] // Post : /api/account/login
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            if (user == null) return Unauthorized(HttpContext.Response.StatusCode = 401);
            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);
            if (!result.Succeeded) return Unauthorized(HttpContext.Response.StatusCode = 401);
            return Ok(new UserDto()
            {
                DisplayName = user.DisplayName,
                Email = user.Email,
                Token = await _tokenService.CreateToken(user, _userManager)
            });
        }

        [HttpPost("register")] // Post : /api/Account/register
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            if (CheckEmailExists(registerDto.Email).Result.Value)  /// i user result cause i would break code to get error and throw exception
                return BadRequest("email already in use");

            var user = new AppUser()
            {
                DisplayName = registerDto.DisplayName,
                Email = registerDto.Email,
                PhoneNumber = registerDto.PhoneNumber,
                UserName = registerDto.Email.Split("@")[0] //KhalidAli
            };

            var result = await _userManager.CreateAsync(user, registerDto.Password);
            if (!result.Succeeded) return BadRequest();
            return Ok(new UserDto()
            {
                DisplayName = user.DisplayName,
                Email = user.Email,
                Token = await _tokenService.CreateToken(user, _userManager)
            });
        }

        [Authorize]
        [HttpGet] // Get: /api/account
        public async Task<IActionResult> GetCurrentUser()
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            var user = await _userManager.FindByEmailAsync(email);
            return Ok(new UserDto(){ 
               DisplayName = user.DisplayName,
               Email = user.Email,
               Token = await _tokenService.CreateToken(user, _userManager)
            });
        }

        [Authorize]
        [HttpPut("address")]
        public async Task<IActionResult> UpdateAddress(AddressDto addressDto)
        {
            var address = _mapper.Map<AddressDto,Address>(addressDto);
            var appUser = await _userManager.FindYsreWithAddressByEmail(User);
            appUser.Address = address;
            var result = await _userManager.UpdateAsync(appUser);
            if (!result.Succeeded) return BadRequest();
            return Ok(_mapper.Map<Address, AddressDto>(appUser.Address));
        }

        [Authorize]
        [HttpGet("address")]
        public async Task<IActionResult> GetUserAddress()
        {
            /// i user this code to get address by email but if want to get ues this code 
            /// var email = User.FindFirstValue(ClaimTypes.Email);
            ///var user = await _userManager.FindByEmailAsync(email);
            ///this code not return address cause not included address to return it 
            var appUser = await _userManager.FindYsreWithAddressByEmail(User);
            return Ok(_mapper.Map<Address, AddressDto>(appUser.Address));
        }

        [HttpGet("emailExists")]
        public async Task<ActionResult<bool>>CheckEmailExists(string email)
        {
            return await _userManager.FindByEmailAsync(email) != null;
        }
    }
}
