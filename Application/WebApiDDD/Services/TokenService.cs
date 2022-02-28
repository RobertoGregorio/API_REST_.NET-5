using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using DDD.Domain.Entities;
using Microsoft.IdentityModel.Tokens;

namespace WebApiDDD.Services
{
    public class TokenService : ITokenService
    {
        public string CreateNewJwtToken(string key, string issuer, string audience, UserModel user)
        {
            //claims do payload
            var claims = new []{
                new Claim(ClaimTypes.Name, user.Username),
                new Claim (ClaimTypes.NameIdentifier, Guid.NewGuid().ToString())
            };

            //conteudo da chave secreta em bytes para a criação da chave simetrica
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));

            var  credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token  =  new JwtSecurityToken(issuer:issuer,
            audience:audience,
            claims: claims,
            expires: DateTime.Now.AddMinutes(60),
            signingCredentials: credentials);


            var stringToken = new JwtSecurityTokenHandler().WriteToken(token);

            return stringToken;

         }
    }
}