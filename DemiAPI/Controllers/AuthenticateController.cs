using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using DemiAPI.Authentication;
using System.IdentityModel.Tokens.Jwt;

namespace DemiAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IConfiguration _configuration; 

        public AuthenticateController(UserManager<ApplicationUser> userManager, IConfiguration configuration)
        {
            this.userManager = userManager;
            _configuration = configuration; 
        }
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            ApplicationUser user = await userManager.FindByNameAsync(model.Username); 
           
            if( user !=null && await userManager.CheckPasswordAsync(user, model.Password))
            {
                /*
                 *  var userRoles = await userManager.GetRolesAsync(user);  
  
                var authClaims = new List<Claim>  
                {  
                    new Claim(ClaimTypes.Name, user.UserName),  
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),  
                };  
  
                foreach (var userRole in userRoles)  
                {  
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));  
                }  
                 */
                SymmetricSecurityKey authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
                SigningCredentials signingCreds = new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256);
                JwtSecurityToken tokenOptions = new(
                     issuer: "http://localhost:5000",
                     //issuer: _configuration["JWTValidIssuer"], //issuer: "https://https://localhost:5000",
                     audience: "http://localhost:5000", 
                     //audience: _configuration["JWT:ValidAudience"], //audience: "https://localhost:5000",
                     expires: DateTime.Now.AddHours(3),
                     claims: new List<Claim>(),
                     signingCredentials: signingCreds
                    );
                string tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
                return Ok(new { Token = tokenString }); 
            }
            return Unauthorized(); 
        }
        
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            var userExists = await userManager.FindByNameAsync(model.Username);
            if (userExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User already exists!" });
            ApplicationUser user = new ApplicationUser()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username
            };

            var result = await userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User creation failed! please check user details and try again" });
            return Ok(new Response { Status = "Success", Message = "User created successfully!" }); 
        }
    }
}
