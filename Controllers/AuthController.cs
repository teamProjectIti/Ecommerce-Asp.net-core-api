using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Extensions;
using WebApplication1.Model.ViewModelIdentity;
using WebApplication1.Model.ViewModelIdentity.SeedRole;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // [Authorize(Roles =UserRole.user)]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly ApplicationContext context;
        private readonly IConfiguration configuration;

        public AuthController(UserManager<ApplicationUser> userManager,
           RoleManager<IdentityRole> roleManager,
           ApplicationContext context, IConfiguration configuration)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.context = context;
            this.configuration = configuration;
        }
        [HttpPost("Register")]

        public async Task<IActionResult> Register([FromBody] registerVM registerVM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("plz, provide all The required fields");
            }
            var emailAddressExist = await userManager.FindByEmailAsync(registerVM.emailAddress);
            if (emailAddressExist != null)
            {
                return BadRequest($"User = {registerVM.emailAddress} already exists");
            }
            ApplicationUser user = new ApplicationUser()
            {
                FirstName = registerVM.FirstName,
                lastName = registerVM.LastName,
                Email = registerVM.emailAddress,
                UserName = registerVM.userName,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            var result = await userManager.CreateAsync(user, registerVM.Password);

            if (result.Succeeded)
            {
                switch (registerVM.Role)
                {

                    case UserRole.Manager:
                        await userManager.AddToRoleAsync(user, UserRole.Manager);
                        break;
                    case UserRole.user:
                        await userManager.AddToRoleAsync(user, UserRole.user);
                        break;
                    default:
                        break;
                }


                var tokenValue = await GenraterJwtTokenAsync(user);
                return Ok(tokenValue);
            };
            return BadRequest("user could not be create");
        }
        [HttpPost("login-user")]
        public async Task<IActionResult> login([FromBody] loginVM loginVM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("plz, provide all The required fields");
            }
            var emailAddressExist = await userManager.FindByEmailAsync(loginVM.emailAddress);
            if (emailAddressExist != null && await userManager.CheckPasswordAsync(emailAddressExist, loginVM.Password))
            {
                var tokenValue = await GenraterJwtTokenAsync(emailAddressExist);
                return Ok(tokenValue);
            }
            return Unauthorized();
        }
        [Authorize]

        [HttpGet("GetCrrentUser")]
        public async Task<ActionResult<AuthResultVM>> GetCrrentUser()
        {
            try
            {
                // var email=HttpContext.User?.Claims?.FirstOrDefault(x=>x.Type==ClaimTypes.Email)?.Value;
                // var user=await _userManager.FindByEmailAsync(email);
                var user = await userManager.FindByEmailFromClaimsPrinciple(HttpContext.User);
                var tokenValue = await GenraterJwtTokenAsync(user);
                return Ok(tokenValue);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [Authorize]
        [HttpPut("UpdateUser")]
        public async Task<ActionResult<AuthResultVM>> UpdateUser([FromBody] registerVM registerVM)
        {
            var user = await userManager.FindByEmailWithAddressAsync(HttpContext.User);
            user.City = registerVM.userName;
            user.Email = registerVM.emailAddress;
            user.FirstName = registerVM.FirstName;
            user.lastName = registerVM.LastName;
            var result = await userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                switch (registerVM.Role)
                {

                    case UserRole.Manager:
                        await userManager.AddToRoleAsync(user, UserRole.Manager);
                        break;
                    case UserRole.user:
                        await userManager.AddToRoleAsync(user, UserRole.user);
                        break;
                    default:
                        break;
                }


                var tokenValue = await GenraterJwtTokenAsync(user);
                return Ok(tokenValue);
            };
            return BadRequest();
        }

        private async Task<AuthResultVM> GenraterJwtTokenAsync(ApplicationUser user)
        {
            var AuthClims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name,user.UserName),
                new Claim(ClaimTypes.NameIdentifier,user.Id),
                new Claim(JwtRegisteredClaimNames.Email,user.Email),
                new Claim(JwtRegisteredClaimNames.Sub,user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            //add user role claims
            var userRoles= await userManager.GetRolesAsync(user);
            foreach (var item in userRoles)
            {
                AuthClims.Add(new Claim(ClaimTypes.Role, item));
            }
            var authreisterKey =
                 new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:SecrtKey"]));
               var token = new JwtSecurityToken(
                issuer: configuration["JWT:ValidIssuer"],
                audience: configuration["JWT:ValidAudience"],
                expires: DateTime.UtcNow.AddHours(5),
                claims: AuthClims,
                signingCredentials: new SigningCredentials(authreisterKey, SecurityAlgorithms.HmacSha256));

            var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);
            var role = await userManager.GetRolesAsync(user);
            bool state = false;
            string data = "";
            foreach (var item in role)
            {
               data= item;
                 
            }
           
            AuthResultVM response = new AuthResultVM()
            {
                Token = jwtToken,
                ExpiredTime = token.ValidTo,
                FirstName = user.FirstName,
                LastName = user.lastName,
                Email = user.Email,
                Role = data
            };
            return response;
        }
    }
}
