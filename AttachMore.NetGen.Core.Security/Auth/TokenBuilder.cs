using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using AttachMore.NextGen.Infrastructure.DataAccess.EntityModel.Account;
using Microsoft.IdentityModel.Tokens;

namespace AttachMore.NetGen.Core.Security.Auth
{
    public class TokenBuilder
    {
        public string Build(User user, DateTime expireDate)
        {
            var handler = new JwtSecurityTokenHandler();

            //var claims = new List<Claim>();

            //foreach (var userRole in roles)
            //{
            //    claims.Add(new Claim(ClaimTypes.Role, userRole));
            //}

            var claims = new Claim[]
            {
                new Claim(ClaimTypes.Email, user.Email) ,
                new Claim("UserId",user.Id.ToString())
        };

            ClaimsIdentity identity = new ClaimsIdentity(claims);

            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = TokenAuthOption.Issuer,
                Audience = TokenAuthOption.Audience,
                SigningCredentials = TokenAuthOption.SigningCredentials,
                Subject = identity,
                Expires = expireDate
            });

            return handler.WriteToken(securityToken);
        }
    }
}
