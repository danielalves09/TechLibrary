﻿using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TechLibrary.Api.Domain.Entities;

namespace TechLibrary.Api.Infraestructure.Security.Tokens.Access
{
    public class JwtTokenGenerator
    {
        public string Generate(User user)
        {
            var claim = new Claim[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString())                    
                };


            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Expires = DateTime.UtcNow.AddMinutes(60),
                Subject = new ClaimsIdentity(claim),
                SigningCredentials = new SigningCredentials(SecurityKey(), SecurityAlgorithms.HmacSha256Signature),
            };

            var tokenHandler =  new JwtSecurityTokenHandler();

            var  securityToken = tokenHandler.CreateToken(tokenDescriptor);
        
            return tokenHandler.WriteToken(securityToken);
        }

        private SymmetricSecurityKey SecurityKey()
        {

            //Lembrar de nunca colocar a chave no codigo
            var signKey = "QKa21qzcpA4fr1DUlsp6tINd7nnOCA4J";
            var symetricKey =  Encoding.UTF8.GetBytes(signKey);

            return new SymmetricSecurityKey(symetricKey);
        
        }
    }
}
