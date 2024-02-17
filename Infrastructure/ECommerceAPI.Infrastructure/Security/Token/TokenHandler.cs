using ECommerceAPI.Application.Security.Token;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using p = ECommerceAPI.Application.Abstractions.DTOs;

namespace ECommerceAPI.Infrastructure.Security.Token
{
    public class TokenHandler : ITokenHandler
    {
        readonly IConfiguration _configuration;

        public TokenHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public p.Token CreateAccessToken(int minute)
        {
           p.Token token = new();

            // We are taking securitykeys symmetric
            SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(_configuration["Token:SecurityKey"]));

            SigningCredentials signingCredentials = new(securityKey,SecurityAlgorithms.HmacSha256);

            token.Expiration = DateTime.UtcNow.AddMinutes(minute);
            JwtSecurityToken securityToken = new(
                audience: _configuration["Token:Audience"],
                issuer: _configuration["TokenIssuer"],
                expires:token.Expiration,
                notBefore:DateTime.UtcNow,
                signingCredentials:signingCredentials);

            JwtSecurityTokenHandler tokenHandler = new();
            token.AccessToken=tokenHandler.WriteToken(securityToken);
            return token;
        }
    }
}
