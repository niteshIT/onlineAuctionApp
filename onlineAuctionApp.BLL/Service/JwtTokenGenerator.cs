using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using onlineActionApp.DLL.Models;
using onlineAuctionApp.BLL.IServices;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace onlineAuctionApp.BLL.Service
{
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        

        

        public string GenerateToken(User user)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("your_secret_key_here_and_this_must_be_long_so_that_it_can_create_hash"); // Replace with your secret key
            var identity = new ClaimsIdentity(new Claim[]
            {
            new Claim(ClaimTypes.Name, user.Name),
            new Claim(ClaimTypes.Role, user.Role),
            new Claim("userid", user.Id.ToString())
            });
            var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = identity,
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = credentials
            };
            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            return jwtTokenHandler.WriteToken(token);
        }
    }
}
