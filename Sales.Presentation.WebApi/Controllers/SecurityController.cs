using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Sales.Presentation.WebApi.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Presentation.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class SecurityController:ControllerBase
    {
        private UserManager<IdentityUser> _identityUserManager;
        private SignInManager<IdentityUser> _identitySignInManager;
        private readonly IConfiguration _configuration;

        public SecurityController
        (
            UserManager<IdentityUser> identityUserManager,
            SignInManager<IdentityUser> identitySignInManager,
            IConfiguration configuration
        )
        {
            this._identitySignInManager = identitySignInManager;
            this._identityUserManager = identityUserManager;
            this._configuration = configuration;
        }


        [HttpPost]
        [Route("RegisterNewUser")]
        public async Task RegisterNewUser([FromBody]RegisterNewUser registerNewUser)
        {
            var result = await this._identityUserManager.CreateAsync(new IdentityUser()
            {
                UserName = registerNewUser.UserName,
                Email = registerNewUser.Email
            }, registerNewUser.Password);
            if (!result.Succeeded)
            {
                var errors = string.Join(" , ", result.Errors.Select(x => x.Description));
                throw new Exception($"Error : { errors }");
            }
        }

        [HttpPost]
        [Route("SignIn")]
        public async Task<object> SignIn([FromBody]LoginAttemp LoginAttemp)
        {
            var user = await this._identityUserManager.FindByNameAsync(LoginAttemp.UserName);
            var singInResult = await this._identitySignInManager.PasswordSignInAsync(user, LoginAttemp.Password, true, false);
            if (singInResult.Succeeded)
            {
                var token = await GenerateJwtToken(user.Email, user);
                return new {
                    Token=token
                };
            }
            else
            {
                throw new Exception($"Login failed!");
            }
        }

        private async Task<object> GenerateJwtToken(string email, IdentityUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(Convert.ToDouble(_configuration["JwtExpireDays"]));

            var token = new JwtSecurityToken(
                _configuration["JwtIssuer"],
                _configuration["JwtIssuer"],
                claims,
                expires: expires,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
